using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using static UnityEditor.Progress;

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
            _GM.playerBins[playerControls.playerNum].SetActive(true);


            var bin = _GM.playerBins[playerControls.playerNum].GetComponent<GetBinScript>().binMannager;
            bin.assigedPlayer = playerControls.gameObject;

            ChangePlayerColour();

            transform.parent = playerControls.transform;
            transform.position = playerControls.transform.position;

        }


    }

    void ChangePlayerColour()
    {
        var renderChild = _GM.playerGameObjList[playerControls.playerNum].GetComponent<PlayerController>().colourIndicator.GetComponent<Renderer>();
        var bin = _GM.playerBins[playerControls.playerNum].GetComponent<GetBinScript>().binRenderer.GetComponent<Renderer>();

        switch (playerControls.playerNum)
        {
            case 0:

                renderChild.material.color = Color.red;
                bin.material.color = Color.red;
                break;
            case 1:
                renderChild.material.color = Color.blue;
                bin.material.color = Color.blue;

                break;
            case 2:
                renderChild.material.color = Color.yellow;
                bin.material.color = Color.yellow;

                break;
            case 3:
                renderChild.material.color = Color.green;
                bin.material.color = Color.green;

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

    public void OnEmote(int emoteNum)
    {
        print("Emote" +  emoteNum);
        playerControls.OnEmote(emoteNum);
    }
}
