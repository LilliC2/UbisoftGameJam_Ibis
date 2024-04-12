using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public enum GameState { Menu, Playing, Paused, GameOver}

public class GameManager : Singleton<GameManager>
{
    public GameObject[] spawnPoints_InGame;
    public GameObject[] spawnPoints_MainMenu;
    public GameObject[] spawnPoints_GameOver;
    public List<PlayerInput> playerInputList = new List<PlayerInput>();
    public List<GameObject> playerGameObjList = new List<GameObject>();
    public GameObject[] playerBins;

    public int[] playerScore;

    public int playerCount;
    [SerializeField] GameObject mainMenuColliders;

    //bind action
    public InputAction joinAction;
    public InputAction leaveAction;

    public int totalPlayerCount; //number of players currently in game

    public LayerMask groundMask;
    public LayerMask pickUpPropsMask;
    public LayerMask pickUpProps_and_HeldItemsMask;
    public LayerMask heldPropMask;

    public event System.Action<PlayerInput> PlayerJoinedGame;
    public event System.Action<PlayerInput> PlayerLeftGame;
    // Start is called before the first frame update

    public bool timerIsRunning;
    public float timerMax = 120f;
    public float timeRemaining;


    void Start()
    {
        foreach (var bin in playerBins)
        {
           bin.SetActive(false);
        }


        joinAction.Enable();                                                       
        leaveAction.Enable();
        //subscribe method to action
        joinAction.performed += context => JoinAction(context); //pass context to JoinAction()
        leaveAction.performed += context => LeaveAction(context);

        timeRemaining = timerMax;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha0)) _IS.GetTotalItemCount();

        if (_UI.uiState == UIState.Playing)
        {
            timerIsRunning = true;
            //OnGameStart();
        }

        if (timerIsRunning)
        {
            if (timeRemaining  > 0)
            {
                //OnGameStart();
                timeRemaining -= Time.deltaTime;
                _UI.UpdateTimerText(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning=false;
                _UI.uiState = UIState.GameOver;
                _UI.Setup();
            }
        }


    }

    public void OnGameStart()
    {
       // mainMenuColliders.SetActive(false);
        //spawn trash
        _IS.InitalTrashSpawn();
        //start NPC spawnin
        _NPC.SpawnChance();

        //put players in right spawn pos
        for (int i = 0; i < playerGameObjList.Count; i++)
        {
            playerGameObjList[i].transform.position = spawnPoints_InGame[i].transform.position;
        }
        foreach (var player in playerInputList)
        {
            player.currentActionMap = player.actions.FindActionMap("Gameplay");

        }

    }

    void OnPlayerJoined(PlayerInput playerInput)
    {
        playerInputList.Add(playerInput);

        int index = playerInputList.IndexOf(playerInput);


        if (PlayerJoinedGame != null) //check if anything is subscribed
        {
            PlayerJoinedGame(playerInput); //be able to send this to anything that wants it   
        }
    }

    void OnPlayerLeft(PlayerInput playerInput)
    {

    }

    void JoinAction(InputAction.CallbackContext context)
    {

        PlayerInputManager.instance.JoinPlayerFromActionIfNotAlreadyJoined(context); //getting controller from button input
        _UI.ReadyPlayer();
        _UI.readyCountMax = _GM.playerCount;
        _UI.UpdateReadyUPText(_UI.readyCountMax, _GM.playerCount);
        print("i Join");

    }
    void LeaveAction(InputAction.CallbackContext context)
    {
        if (playerInputList.Count > 1) //make sure theres more than 1 player
        {
            foreach (var player in playerInputList)
            {
                //search for all devices registered to player
                foreach (var device in player.devices)
                {
                    //if device matches devices used to prompt leave action
                    if (device != null && context.control.device == device)
                    {
                        UnregisterPlayer(player);
                        return;
                    }
                }
            }
        }

    }

    void UnregisterPlayer(PlayerInput playerInput)
    {

        playerInputList.Remove(playerInput);

        if (PlayerLeftGame != null) //check for listeners
        {
            PlayerLeftGame(playerInput);
        }

       // playerInput.GetComponentInParent<PlayerController>().DestroyPlayer();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnGameEnd()
    {
        _UI.OnGameOver();
    }
}
