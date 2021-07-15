using System;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using LitJson;

namespace WinFormsServer
{
    public delegate void ClientConnectionEventHandler(string clientId);
    public delegate void ClientNameChangedEventHandler(string clientId, string newName);
    public delegate void ClientGroupEventHandler(string clientId, string groupName);

    public delegate void MessageReceivedEventHandler(string senderClientId, string message);

    public class SimpleHub : Hub
    {
        static ConcurrentDictionary<string, string> _users = new ConcurrentDictionary<string, string>();

        public static event ClientConnectionEventHandler ClientConnected;
        public static event ClientConnectionEventHandler ClientDisconnected;
        public static event ClientNameChangedEventHandler ClientNameChanged;

        public static event ClientGroupEventHandler ClientJoinedToGroup;
        public static event ClientGroupEventHandler ClientLeftGroup;

        public static event MessageReceivedEventHandler MessageReceived;

        public static event Action<string> PlayerJoinedGame;

        public static event Action<int,Marks> GameAction;

        private static int gameIdCounter;

        public static void ClearState()
        {
            _users.Clear();
        }

        //Called when a client is connected
        public override Task OnConnected()
        {
            _users.TryAdd(Context.ConnectionId, Context.ConnectionId);

            ClientConnected?.Invoke(Context.ConnectionId);

            Clients.Caller.setId(Context.ConnectionId);

            return base.OnConnected();
        }

        //Called when a client is disconnected
        public override Task OnDisconnected(bool stopCalled)
        {
            string userName;
            _users.TryRemove(Context.ConnectionId, out userName);

            ClientDisconnected?.Invoke(Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }        

        #region Client Methods

        public void SetUserName(string userName)
        {
            _users[Context.ConnectionId] = userName;

            ClientNameChanged?.Invoke(Context.ConnectionId, userName);
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.Add(Context.ConnectionId, groupName);

            ClientJoinedToGroup?.Invoke(Context.ConnectionId, groupName);
        }

        public async Task LeaveGroup(string groupName)
        {
            await Groups.Remove(Context.ConnectionId, groupName);

            ClientLeftGroup?.Invoke(Context.ConnectionId, groupName);
        }        

        public void Send(string msg)
        {
            Clients.All.addMessage(_users[Context.ConnectionId], msg);

            MessageReceived?.Invoke(Context.ConnectionId, msg);
        }

        public void Join()
        {
            FrmServer.usersInPool.Enqueue(Context.ConnectionId);

            PlayerJoinedGame.Invoke(FindPlayer(Context.ConnectionId).Name);

            CheckForCreateGame();
        }

        private ClientItem FindPlayer(string id)
        {
            foreach(var client in FrmServer.clients)
            {
                if(client.Id == id)
                {
                    return client;
                }
            }

            return null;
        }

        private void CheckForCreateGame()
        {
            if(FrmServer.usersInPool.Count >= 2)
            {
                string player1 = FrmServer.usersInPool.Dequeue();

                string player2 = FrmServer.usersInPool.Dequeue();

                StartGame(player1, player2);

                CheckForCreateGame();
            }
        }

        private void StartGame(string player1 , string player2)
        {

            ClientItem client1, client2;

            client1 = FindPlayer(player1);

            client2 = FindPlayer(player2);

            client1.marker = Marks.X;
            Clients.Client(player1).StartGame(client2.Name,Marks.X);


            client2.marker = Marks.O;
            Clients.Client(player2).StartGame(client1.Name, Marks.O);

            XOGameData gameData = new XOGameData(new[] { client1, client2 });

            FrmServer.games.Add(gameIdCounter,gameData);

            gameData.Turn();

            client1.currentGameId = gameIdCounter;
            client2.currentGameId = gameIdCounter;

            gameIdCounter++;
        }

        public void Action(int index)
        {
            ClientItem clientItem = FindPlayer(Context.ConnectionId);

            XOGameData gameData = FrmServer.games[clientItem.currentGameId];

            gameData.SetMarker(index, clientItem.marker);

            GameAction.Invoke(index, clientItem.marker);

        }

        #endregion        
    }
}
