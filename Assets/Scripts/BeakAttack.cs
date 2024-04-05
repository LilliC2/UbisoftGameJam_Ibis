using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakAttack : GameBehaviour
{
    public float forceApplied = 500;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject)
            {
                var direction = (collision.gameObject.transform.position - gameObject.transform.position).normalized;
                //apply force
                print("Hit player with beak");

                collision.gameObject.GetComponent<PlayerController>().GotHit(direction, forceApplied);


            }

        }
    }
}
