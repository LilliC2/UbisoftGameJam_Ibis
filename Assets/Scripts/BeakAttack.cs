using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakAttack : GameBehaviour
{
    public float forceApplied = 500;
    PlayerController controller;
    public void Awake()
    {
        controller = gameObject.transform.root.GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            if (collision.gameObject != gameObject.transform.root.gameObject)
            {
                var direction = (collision.gameObject.transform.position - gameObject.transform.position).normalized;
                //apply force
                print("Hit player with beak");

                var newForce = forceApplied;

                if(controller.isHoldingTrash)
                {
                    newForce =+ controller.targetTrash.GetComponent<TrashItem>().forceApplied/2;
                }

                collision.gameObject.GetComponent<PlayerController>().GotHit(direction, newForce);


            }

        }
    }
}
