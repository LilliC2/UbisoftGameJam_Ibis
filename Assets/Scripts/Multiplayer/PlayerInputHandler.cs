using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerInputHandler : GameBehaviour
{
    public GameObject playerPrefab;
    PlayerController playerControls;

    PlayerInput playerInput;

    Vector3 startPos = new Vector3(0, 0, 0);

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();


        if (playerPrefab != null)
        {
            playerControls = GameObject.Instantiate(playerPrefab, _GM.spawnPoints[_GM.playerGameObjList.Count].transform.position, transform.rotation).GetComponent<PlayerController>();
            var go = playerControls.gameObject;
            _GM.playerGameObjList.Add(go);
            playerControls.playerNum = _GM.playerGameObjList.IndexOf(go);

            ChangePlayerColour();

            transform.parent = playerControls.transform;
            transform.position = playerControls.transform.position;

        }


    }

    void ChangePlayerColour()
    {
        switch(playerControls.playerNum)
        {
            case 0:
                _GM.playerGameObjList[0].GetComponent<Renderer>().material.color = Color.red; break;
            case 1:
                _GM.playerGameObjList[1].GetComponent<Renderer>().material.color = Color.blue; break;
            case 2:
                _GM.playerGameObjList[2].GetComponent<Renderer>().material.color = Color.green; break;
            case 3:
                _GM.playerGameObjList[3].GetComponent<Renderer>().material.color = Color.yellow; break;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        playerControls.OnMove(context);
    }
    
    public void OnMoveHead(InputAction.CallbackContext context)
    {
        playerControls.OnMoveHead(context);
    }
}
