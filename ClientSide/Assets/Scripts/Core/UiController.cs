using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    // Start is called before the first frame update

    public static UiController Instance;



    public GameObject connectPanel;

    public GameObject startGamePanel;

    public Button joinGameButton;

    public GameObject corePanel;

    public GameObject gameOverPanel;


    public Text playerNameText, opponentNameText;


    public GameObject coverToPreventTouchPanel;

    public Text turnText;

    public Text winnerText;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void CloseConnectPanel()
    {
        connectPanel.SetActive(false);
    }

    public void OpenStartGamePanel()
    {
        startGamePanel.SetActive(true);
    }

    public void CloseStartGamePanel()
    {
        startGamePanel.SetActive(false);
    }

    public void OpenCorePanel()
    {
        corePanel.SetActive(true);
    }

    public void BackToStartGamePanel()
    {
        corePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        connectPanel.SetActive(false);
        startGamePanel.SetActive(true);
        joinGameButton.interactable = true;
    }

    public void SetNames(string opponentName)
    {

        playerNameText.text = GameController.Instance.devicePlayer.playerName;

        opponentNameText.text = opponentName;
    }

    public void SetTurn(bool isDevicePlayerTurn)
    {
        if (isDevicePlayerTurn)
        {
            coverToPreventTouchPanel.SetActive(false);
            turnText.text = "Your Turn !";
        }
        else
        {
            coverToPreventTouchPanel.SetActive(true);
            turnText.text = "Enemy Turn";
        }
    }

    public void GameOver(string playerName)
    {
        gameOverPanel.SetActive(true);
        
        coverToPreventTouchPanel.SetActive(false);

        winnerText.text = playerName;
    }
    
    
    
    
    
}
