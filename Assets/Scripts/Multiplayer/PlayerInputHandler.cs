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
        var renderChild = _GM.playerGameObjList[playerControls.playerNum].GetComponentsInChildren<Renderer>();

        switch (playerControls.playerNum)
        {
            case 0:

                foreach (var item in renderChild)
                {
                    item.material.color = Color.red; 
                }
                break;
            case 1:
                foreach (var item in renderChild)
                {
                    item.material.color = Color.blue;
                }
                break;
            case 2:
                foreach (var item in renderChild)
                {
                    item.material.color = Color.yellow;
                }
                break;
            case 3:
                foreach(var item in renderChild)
                {
                    item.material.color = Color.green;
                }
                break;
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

    public void OnResetHeadRotations()
    {
        playerControls.OnResetHeadRotations();
    }

    public void OnPickUpItem(InputAction.CallbackContext context)
    {
        playerControls.PickUpTargetItem(context);
    }

    public void OnHonk(InputAction.CallbackContext context)
    {
        playerControls.OnHonk(context);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        playerControls.OnAttack();
    }
    
    public void OnThrow()
    {
        playerControls.OnThrow();
    }
}
