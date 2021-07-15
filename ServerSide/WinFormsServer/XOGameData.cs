using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinFormsServer
{
    public class XOGameData
    {


        private ClientItem[] _players;

        private int[] grid = new int[9];

        private bool[] gridUsed = new bool[9];

        private IHubContext hubContext;

        private Marks currentMarker;

        public XOGameData(ClientItem[] players)
        {
            _players = players;
            hubContext = GlobalHost.ConnectionManager.GetHubContext<SimpleHub>();

            for (int i = 0; i < grid.Length; i++)
            {
                grid[i] = -1;
            }
        }

        public void SetMarker(int index , Marks marker)
        {
            grid[index] = (int)marker;

            gridUsed[index] = true;

            currentMarker = marker;

            Action(index);

            Turn(marker);
        }

        private bool CheckGrid()
        {
            if (grid[0] == (int)currentMarker && grid[1] == (int)currentMarker && grid[2] == (int)currentMarker)
            {
                SendWinner((int)currentMarker);
                return true;
            }

            if (grid[3] == (int)currentMarker && grid[4] == (int)currentMarker && grid[5] == (int)currentMarker)
            {
                SendWinner((int)currentMarker);
                return true;
            }

            if (grid[6] == (int)currentMarker && grid[7] == (int)currentMarker && grid[8] == (int)currentMarker)
            {
                SendWinner((int)currentMarker);
                return true;
            }

            if (grid[0] == (int)currentMarker && grid[3] == (int)currentMarker && grid[6] == (int)currentMarker)
            {
                SendWinner((int)currentMarker);
                return true;
            }

            if (grid[1] == (int)currentMarker && grid[4] == (int)currentMarker && grid[7] == (int)currentMarker)
            {
                SendWinner((int)currentMarker);
                return true;
            }

            if (grid[2] == (int)currentMarker && grid[5] == (int)currentMarker && grid[8] == (int)currentMarker)
            {
                SendWinner((int)currentMarker);
                return true;
            }

            if (grid[0] == (int)currentMarker && grid[4] == (int)currentMarker && grid[8] == (int)currentMarker)
            {
                SendWinner((int)currentMarker);
                return true;
            }

            if (grid[2] == (int)currentMarker && grid[4] == (int)currentMarker && grid[6] == (int)currentMarker)
            {
                SendWinner((int)currentMarker);
                return true;
            }

            if (CheckAllGridUsed())
            {
                currentMarker = Marks.None;
                SendWinner((int)currentMarker);
                return true;
            }
                

            return false;
        }

        private bool CheckAllGridUsed()
        {
            for (int i = 0; i < gridUsed.Length; i++)
            {
                if (!gridUsed[i])
                    return false;
            }

            return true;
        }

        private void SendWinner(int marker)
        {
            
            for (int i = 0; i < _players.Length; i++)
            {
                hubContext.Clients.Client(_players[i].Id).Winner(marker);
            }
        }

        private void Action(int index)
        {
            for (int i = 0; i < _players.Length; i++)
            {
                hubContext.Clients.Client(_players[i].Id).Action(index);
            }
        }

        public void Turn(Marks marker = Marks.None)
        {
            ClientItem currentClientTurn = null;

            if(marker == Marks.None)
            {
                Random random = new Random();

                currentClientTurn = _players[random.Next(0, 2)];
            }
            else
            {
                foreach (var client in _players)
                {
                    if(client.marker != marker)
                    {
                        currentClientTurn = client;
                    }
                }
            }

            if (CheckGrid())
                return;


            if(currentClientTurn != null)
            {
                for (int i = 0; i < _players.Length; i++)
                {
                    hubContext.Clients.Client(_players[i].Id).Turn(currentClientTurn.Id);
                }
            }

        }
    }

    public enum Marks
    {
        X,O,None
    }
}
