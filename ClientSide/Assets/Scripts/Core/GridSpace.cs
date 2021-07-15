using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    // Start is called before the first frame update

    private GameController _gameController;

    public Button button;
    
    public Text text;

    public Marks marker;

    public int index;
    
    void Start()
    {
        _gameController = GameController.Instance;
        marker = Marks.None;
    }

    public void OnClick()
    {
        _gameController.SetMark(this);
    }

    public void SetMark()
    {
        button.interactable = false;
        text.text = _gameController.currentPlayer.marker.ToString();
        marker = _gameController.currentPlayer.marker;
    }

    public void ResetGridSpace()
    {
        
        button.interactable = true;
        text.text = "";
        marker = Marks.None;
    }
}
