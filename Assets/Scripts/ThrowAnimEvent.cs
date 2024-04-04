using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAnimEvent : GameBehaviour
{
    PlayerController playerController;
    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
    }
    public void ThrowEvent()
    {
        print("Throw event");
        //playerController.Throw();
    
    
    }
}
