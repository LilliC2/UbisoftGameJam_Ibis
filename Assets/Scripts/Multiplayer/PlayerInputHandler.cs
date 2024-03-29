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

            transform.parent = playerControls.transform;
            transform.position = playerControls.transform.position;

        }


    }

    public void OnMove(InputAction.CallbackContext context)
    {
        playerControls.OnMove(context);
    }
}
