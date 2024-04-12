using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

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
    public GameObject mainMenuCamera;
    public Image[] mmIcon;
    public Image player1Icon;
    public Image player2Icon;
    public Image player3Icon;
    public Image player4Icon;
    public Sprite[] connectionIcon; // 0 = disconnected, 1 = connected, 2 = ready
    public int readyCountMax;
    public int readyCountCurrent = 0;
    public TMP_Text readyupText;
    public List<bool> readyPlayer;
    public bool readyP2;
    public bool readyP3;
    public bool readyP4;

    [Header("In-Game UI")]
    public GameObject playingCamera;
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
    public int playerNumber;

    [Header("Pause")]
    public Image player1ready;
    public Image player2ready;
    public Image player3ready;
    public Image player4ready;
    public Sprite[] readyIcon; // 0 = not ready, 1 = ready

    [Header("Game Over")]
    public GameObject gameOverCamera;
    public TMP_Text player1EndScore;
    public TMP_Text player2EndScore;
    public TMP_Text player3EndScore;
    public TMP_Text player4EndScore;
    public GameObject player1stSpawnPos;
    public GameObject player2ndSpawnPos;
    public GameObject player3rdSpawnPos;
    public GameObject player4thSpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        uiState = UIState.MainMenu;
        player1Score.text = "0";
        player2Score.text = "0";
        player3Score.text = "0";
        player4Score.text = "0";
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.P))
        {
            uiState = UIState.Playing;
            Setup();
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            uiState = UIState.MainMenu;
            Setup();
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            uiState = UIState.GameOver;
            Setup();
        }
    }

    public void Setup()
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
                mainMenuCamera.SetActive(true);
                playingCamera.SetActive(false);
                gameOverCamera.SetActive(false);


                break;

            case UIState.Playing:
                //GameObject
                mainMenuUI.SetActive(false);
                ingameUI.SetActive(true);
                pauseUI.SetActive(false);
                gameOverUI.SetActive(false);
                //camera
                mainMenuCamera.SetActive(false);
                playingCamera.SetActive(true);
                gameOverCamera.SetActive(false);

                _GM.timerIsRunning = true;


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
                mainMenuCamera.SetActive(false);
                playingCamera.SetActive(false);
                gameOverCamera.SetActive(true);

                _GM.OnGameEnd();

                break;
        }
    }
    #region Main Menu

    public void ToMainMenu()
    {
        uiState = UIState.MainMenu;
        Setup();
    }

    public void ReadyUp()
    {

        bool AllPlayersReady = true;

        foreach (var player in readyPlayer)
        {
            if(player==false) AllPlayersReady = false;
        }

        if(AllPlayersReady == true)
        {
            uiState = UIState.Playing;
            Setup();
            _GM.OnGameStart();
        }



    }

    public void UpdateReadyUPText(int _PR, int _MP)
    {
      //  readyupText.text = "[" + _PR + "/" + _MP + "]";
    }

    public void ReadyPlayer()
    {
        print("bin is ready");
        
        int maxPlayers = Mathf.Min(_GM.playerCount, 4);

        print(maxPlayers);

        for (int i = 0; i < maxPlayers; i++)
        {
            switch (i)
            {
                case 0:
                    print("p1 is here");
                    player1Icon.sprite = connectionIcon[1];
                    print("p1 was here");
                    break;
                case 1:
                    player2Icon.sprite = connectionIcon[1];
                    break;
                case 2:
                    player3Icon.sprite = connectionIcon[1];
                    break;
                case 3:
                    player4Icon.sprite = connectionIcon[1];
                    break;
            }
        }
    }

    public void QuitGme()
    {
        _GM.QuitGame();
    }

    #endregion

    #region In-Game
    public void StartPlaying()
    {
        uiState = UIState.Playing;
        Setup();
    }

    public void UpdateScoreText(int _score, int _playerNumber)
    {
        print("binned");
        switch (_playerNumber)
        {
            case 0:
                player1Score.text = _score.ToString();
                player1EndScore.text = _score.ToString();
                print("p1");
                break;

            case 1:
                player2Score.text = _score.ToString();
                player2EndScore.text = _score.ToString();
                break;

            case 2:
                player3Score.text = _score.ToString();
                player3EndScore.text = _score.ToString();
                break;

            case 3:
                player4Score.text = _score.ToString();
                player4EndScore.text = _score.ToString();
                break;
        }
    }

    public void UpdateTimerText(float _timer)
    {
        timerText.text = _timer.ToString("F0");
    }

    #endregion

    #region Game Over

    public void OnGameOver()
    {
        GameObject firstPlace = new();
        float firstPlaceScore = new();
        float secondPlaceScore = new();
        float thirdPlaceScore = new();
        float fourthPlaceScore = new();
        GameObject secondPlace = new();
        GameObject thirdPlace = new();
        GameObject fourthPlace = new();


        List<int> scoreList = new();

        for (int i = 0; i < _GM.playerBins.Length; i++)
        {
            scoreList.Add(_GM.playerBins[i].GetComponent<GetBinScript>().binMannager.binCurrentScore);
        }

        scoreList.Sort();


        for (int i = 0; i < scoreList.Count; i++)
        {
            for (int v = 0; v < _GM.playerGameObjList.Count; v++)
            {
                if(scoreList[i] == _GM.playerBins[v].GetComponent<GetBinScript>().binMannager.binCurrentScore)
                {
                    if (i == scoreList.Count-1)
                    {

                        firstPlace = _GM.playerGameObjList[v];
                        print(firstPlace.name + " got score " + scoreList[scoreList.Count - 1]);

                    }
                    if (i == scoreList.Count-2) secondPlace = _GM.playerGameObjList[v];
                    if (i == scoreList.Count-3) thirdPlace = _GM.playerGameObjList[v];
                    if (i == scoreList.Count - 4) fourthPlace = _GM.playerGameObjList[v];
                }
            }
        }

     //  player1EndScore =

    }


    public int[] SortArray(int[] array, int length)
    {
        for (int i = 1; i < length; i++)
        {
            var key = array[i];
            var flag = 0;
            for (int j = i - 1; j >= 0 && flag != 1;)
            {
                if (key < array[j])
                {
                    array[j + 1] = array[j];
                    j--;
                    array[j + 1] = key;
                }
                else flag = 1;
            }
        }
        return array;
    }

    #endregion

}
