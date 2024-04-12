using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLook : GameBehaviour
{

    PlayerController playerController;
    ParticleSystem PS;
    // Start is called before the first frame update
    void Start()
    {
        playerController = gameObject.transform.root.GetComponent<PlayerController>();
        PS = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(_GM.playerBins[playerController.playerNum].transform.position);
        //Vector3 lookat = gameObject.transform.localEulerAngles;

        //Vector3 dir = new Vector3(-90, lookat.y, 0);
        //var main = PS.main;
        //main.startRotation = dir;
    }
}
