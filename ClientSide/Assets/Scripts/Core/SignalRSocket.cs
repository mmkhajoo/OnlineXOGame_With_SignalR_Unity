using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BestHTTP.SignalR;
using BestHTTP.SignalR.Hubs;
using BestHTTP.SignalR.JsonEncoders;
using BestHTTP.SignalR.Messages;
using UnityEngine.UI;
using LitJson;

public class SignalRSocket : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private string url;

    [SerializeField] private string playerName;

    private Hub _hub;

    private Connection signalRConnection;

    public InputField urlInputField, nameInputField;

    private GameController _gameController;

    private UiController _uiController;

    void Start()
    {
        _gameController = GameController.Instance;
        
        _uiController = UiController.Instance;
    }
    
    public void OnClick()
    {
        url = urlInputField.text;
        playerName = nameInputField.text;
        
        Initialize();
    }

    private void Initialize()
    {
        Uri uri = new Uri(url + "/signalr");

        _hub = new Hub("SimpleHub");

        signalRConnection = new Connection(uri,_hub);

        try
        {
            signalRConnection.Open();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        
        signalRConnection[_hub.Name].On("addMessage",AddMessage);
        
        signalRConnection[_hub.Name].On("setId",SetId);
        
        signalRConnection[_hub.Name].On("StartGame",StartGame);
        
        signalRConnection[_hub.Name].On("Turn",Turn);
        
        signalRConnection[_hub.Name].On("Action",Action);
        
        signalRConnection[_hub.Name].On("Winner",Winner);

        signalRConnection.JsonEncoder = new LitJsonEncoder();

        signalRConnection.OnConnected += OnConnected;
    }

    private void Winner(Hub hub, MethodCallMessage methodcall)
    {
        Debug.Log("Winner Called!");
        
        Marks marker = (Marks)methodcall.Arguments[0];

        if (_gameController.devicePlayer.marker == marker)
        {
            _uiController.GameOver("Winner : "  + _gameController.devicePlayer.playerName);
        }
        else if(_gameController.opponentPlayer.marker == marker)
        {
            _uiController.GameOver( "Winner : "  + _gameController.opponentPlayer.playerName);
        }
        else
        {
            _uiController.GameOver("Tie !");
        }
    }

    private void Action(Hub hub, MethodCallMessage methodcall)
    {
        int index = (int)methodcall.Arguments[0];
        
        _gameController.Action(index);
    }

    private void Turn(Hub hub, MethodCallMessage methodcall)
    {
        string playerId = methodcall.Arguments[0] as string;
        
        Debug.Log($"Turn Called , PlayerID : {playerId}");

        bool flag = playerId == _gameController.devicePlayer.serverId;

        if (flag)
        {
            _gameController.currentPlayer = _gameController.devicePlayer;
        }
        else
        {
            _gameController.currentPlayer = _gameController.opponentPlayer;
        }

        _uiController.SetTurn(flag);
    }

    private void StartGame(Hub hub, MethodCallMessage methodcall)
    {
        
        _gameController.devicePlayer.marker = (Marks)methodcall.Arguments[1];

        string opponentName = methodcall.Arguments[0] as string;


        if (_gameController.devicePlayer.marker == Marks.O)
        {
            _gameController.opponentPlayer.marker = Marks.X;
        }
        else
        {
            _gameController.opponentPlayer.marker = Marks.O;
        }

        _gameController.opponentPlayer.playerName = opponentName;
        
        _uiController.SetNames(opponentName);
        
        _uiController.CloseStartGamePanel();
        
        _uiController.OpenCorePanel();
    }

    private void SetId(Hub hub, MethodCallMessage methodcall)
    {
        _gameController.devicePlayer.serverId = methodcall.Arguments[0].ToString();
        
        Debug.Log("Set Id Called.");
    }

    private void OnConnected(Connection connection)
    {
        Debug.Log("Connected!!!!");
        
        _uiController.CloseConnectPanel();
        _uiController.OpenStartGamePanel();
        
        SendName();
    }

    private void AddMessage(Hub hub, MethodCallMessage methodcall)
    {
        Debug.Log($"Hub Name : {methodcall.Hub}  // Method Name : {methodcall.Method}");

        foreach (var argument in methodcall.Arguments)
        {
            Debug.Log(argument.ToString());
        }
    }

    private void SendName()
    {
        signalRConnection[_hub.Name].Call("SetUserName", playerName);

        _gameController.devicePlayer.playerName = playerName;
    }

    public void JoinGame()
    {
        signalRConnection[_hub.Name].Call("Join");
    }

    public void Action(int index)
    {
        signalRConnection[_hub.Name].Call("Action",index);
    }
    
    
    
    
    
}
