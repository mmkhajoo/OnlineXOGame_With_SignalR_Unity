using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController Instance;

    public GridSpace[] gridSpaces;

    public Player devicePlayer;

    public Player opponentPlayer;
    
    public Player currentPlayer;

    public SignalRSocket signalRSocket;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void SetMark(GridSpace gridSpace)
    {
        signalRSocket.Action(gridSpace.index);
    }

    public void Action(int index)
    {
        gridSpaces[index].SetMark();
    }

    public void ResetGridSpaces()
    {
        foreach (var gridSpace in gridSpaces)
        {
            gridSpace.ResetGridSpace();
        }
    }
    
    
}

public enum Marks
{
    X,O,None
}
