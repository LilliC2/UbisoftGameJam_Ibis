using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum UIState { MainMenu, Playing, Paused, GameOver}

public class UIManager : Singleton<UIManager>
{
    [Header("Main Component")]
    public UIState uiState;
    public GameObject mainMenuUI;
    public GameObject ingameUI;
    public GameObject pauseUI;
    public GameObject gameOverUI;

    [Header("Main Menu")]
    public Camera mainMenuCamera;
    public Image player1Icon;
    public Image player2Icon;
    public Image player3Icon;
    public Image player4Icon;
    public Sprite[] connectionIcon; // 0 = disconnected, 1 = connected

    [Header("In-Game UI")]
    public Camera playingCamera;
    public TMP_Text player1Score;
    public TMP_Text player2Score;
    public TMP_Text player3Score;
    public TMP_Text player4Score;
    PlayerController playerControls;
    public int score1;
    public int score2;
    public int score3;
    public int score4;
    public TMP_Text timerText;

    [Header("Pause")]
    public Image player1ready;
    public Image player2ready;
    public Image player3ready;
    public Image player4ready;
    public Sprite[] readyIcon; // 0 = not ready, 1 = ready

    [Header("Game Over")]
    public Camera gameOverCamera;
    public TMP_Text player1EndScore;
    public TMP_Text player2EndScore;
    public TMP_Text player3EndScore;
    public TMP_Text player4EndScore;

    // Start is called before the first frame update
    void Start()
    {
        uiState = UIState.Playing;
        player1Score.text = "0";
        player2Score.text = "0";
        player3Score.text = "0";
        player4Score.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Setup()
    {
        switch (uiState)
        {
            case UIState.MainMenu:
                //GameObject
                mainMenuUI.SetActive(true);
                ingameUI.SetActive(false);
                pauseUI.SetActive(false);
                gameOverUI.SetActive(false);
                //camera
                mainMenuCamera.enabled = true;
                playingCamera.enabled = false;
                gameOverCamera.enabled = false;

                break;

            case UIState.Playing:
                //GameObject
                mainMenuUI.SetActive(false);
                ingameUI.SetActive(true);
                pauseUI.SetActive(false);
                gameOverUI.SetActive(false);
                //camera
                mainMenuCamera.enabled = false;
                playingCamera.enabled = true;
                gameOverCamera.enabled = false;
                break;

            case UIState.Paused:
                //GameObject
                mainMenuUI.SetActive(false);
                ingameUI.SetActive(false);
                pauseUI.SetActive(true);
                gameOverUI.SetActive(false);
                break;

            case UIState.GameOver:
                //GameObject
                mainMenuUI.SetActive(false);
                ingameUI.SetActive(false);
                pauseUI.SetActive(false);
                gameOverUI.SetActive(true);
                //camera
                mainMenuCamera.enabled = false;
                playingCamera.enabled = false;
                gameOverCamera.enabled = true;
                break;
        }
    }
    #region Main Menu

    public void ToMainMenu()
    {
        uiState = UIState.MainMenu;
        Setup();
    }

    public void ReadyPlayer()
    {
        int maxPlayers = Mathf.Min(_GM.playerCount, connectionIcon.Length);

        for (int i = 0; i < maxPlayers; i++)
        {
            switch (i)
            {
                case 0:
                    player1Icon.sprite = connectionIcon[i];
                    break;
                case 1:
                    player2Icon.sprite = connectionIcon[i];
                    break;
                case 2:
                    player3Icon.sprite = connectionIcon[i];
                    break;
                case 3:
                    player4Icon.sprite = connectionIcon[i];
                    break;
            }
        }
    }

    #endregion

    #region In-Game
    public void StartPlaying()
    {
        uiState = UIState.Playing;
        Setup();
    }

    public void UpdateScoreText(int _score)
    {
        switch (playerControls.playerNum)
        {
            case 0:
                player1Score.text = _score.ToString();
                break;

            case 1:
                player2Score.text = _score.ToString();
                break;

            case 2:
                player3Score.text = _score.ToString();
                break;

            case 3:
                player4Score.text = _score.ToString();
                break;
        }
    }

    public void UpdateTimerText()
    {

    }

    #endregion
}
