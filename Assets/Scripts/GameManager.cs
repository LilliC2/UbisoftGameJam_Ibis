using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
    public GameObject[] spawnPoints;
    public List<PlayerInput> playerInputList = new List<PlayerInput>();
    public List<GameObject> playerGameObjList = new List<GameObject>();

    //bind action
    public InputAction joinAction;
    public InputAction leaveAction;

    public int totalPlayerCount; //number of players currently in game

    public LayerMask groundMask;
    public LayerMask pickUpPropsMask;

    public event System.Action<PlayerInput> PlayerJoinedGame;
    public event System.Action<PlayerInput> PlayerLeftGame;
    // Start is called before the first frame update


    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        joinAction.Enable();
        leaveAction.Enable();
        //subscribe method to action
        joinAction.performed += context => JoinAction(context); //pass context to JoinAction()
        leaveAction.performed += context => LeaveAction(context);
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
