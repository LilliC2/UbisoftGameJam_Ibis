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
    public bool hasReadyUp = false;

    [SerializeField] Color P1;
    [SerializeField] Color P2;
    [SerializeField] Color P3;
    [SerializeField] Color P4;

    PlayerInput playerInput;

    Vector3 startPos = new Vector3(0, 0, 0);

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();


        if (playerPrefab != null)
        {
            playerControls = GameObject.Instantiate(playerPrefab, _GM.spawnPoints_MainMenu[_GM.playerGameObjList.Count].transform.position, transform.rotation).GetComponent<PlayerController>();
            var go = playerControls.gameObject;
            _GM.playerGameObjList.Add(go);
            playerControls.playerNum = _GM.playerGameObjList.IndexOf(go);
            _GM.playerBins[playerControls.playerNum].SetActive(true);

            _GM.playerCount++;

            var bin = _GM.playerBins[playerControls.playerNum].GetComponent<GetBinScript>().binMannager;
            bin.assigedPlayer = playerControls.gameObject;

            ChangePlayerColour();

            transform.parent = playerControls.transform;
            transform.position = playerControls.transform.position;

            _UI.readyPlayer.Add(false);
            _UI.exitPlayer.Add(false); 

        }

        //hasReadyUp = false;

    }

    void ChangePlayerColour()
    {
        var renderChild = _GM.playerGameObjList[playerControls.playerNum].GetComponent<PlayerController>().colourIndicator.GetComponent<Renderer>();
        var bin = _GM.playerBins[playerControls.playerNum].GetComponent<GetBinScript>().binRenderer.GetComponent<Renderer>();
        print(bin.name);

        switch (playerControls.playerNum)
        {
            case 0:

                renderChild.material.color = P1;
                bin.material.color = P1;
                break;
            case 1:
                renderChild.material.color = P2;
                bin.material.color = P2;

                break;
            case 2:
                renderChild.material.color = P3;
                bin.material.color = P3;

                break;
            case 3:
                renderChild.material.color = P4;
                bin.material.color = P4;

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

    public void OnReadyUp()
    {
        _UI.readyPlayer[playerControls.playerNum] = true;
        _UI.mmIcon[playerControls.playerNum].sprite = _UI.connectionIcon[2];
        _UI.ReadyUp();
    }

    public void OnGameExit()
    {
        _UI.exitPlayer[playerControls.playerNum] = true;
        _UI.exitIcon[playerControls.playerNum].sprite = _UI.connectionIcon[3];
        _UI.QuitUP();

        //if (_UI.exitPlayer[playerControls.playerNum]!)
        //{
        //    _UI.exitPlayer[playerControls.playerNum] = true;
        //    _UI.exitIcon[playerControls.playerNum].sprite = _UI.connectionIcon[3];
        //    _UI.QuitUP();
        //}
        //else
        //{
        //    _UI.exitPlayer[playerControls.playerNum] = false;
        //    _UI.exitIcon[playerControls.playerNum].sprite = _UI.connectionIcon[4];
        //    _UI.QuitUP();

        //}






    }
}
