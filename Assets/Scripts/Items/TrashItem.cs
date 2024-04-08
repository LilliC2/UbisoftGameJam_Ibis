using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItem : GameBehaviour
{
    public GameObject holdPos;
    GameObject thrownFrom;
    Rigidbody rb;
    public float forceApplied = 500;
    bool addForce;

    public float aliveTime = 60;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (holdPos != null)
            transform.position = holdPos.transform.position;

    }

    public void PickedUp(GameObject player_holdPos)
    {
        holdPos = player_holdPos;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        transform.position = holdPos.transform.position;

        //rb.Sleep();
        _BM.RemoveFromList(gameObject);
        _SC.RemoveItemToCollectList(gameObject);

    }

    public void Dropped()
    {
        holdPos = null;
       // rb.WakeUp();
        rb.constraints = RigidbodyConstraints.None;
        _BM.AddToList(gameObject);

    }

    public void Thrown(GameObject player)
    {
        print("Called thrown on object for " + gameObject.name);
        holdPos = null;
        rb.constraints = RigidbodyConstraints.None;
        thrownFrom = player;
        _BM.AddToList(gameObject);


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && thrownFrom != null)
        {
            if(collision.gameObject != thrownFrom)
            {
                var direction = (collision.gameObject.transform.position - gameObject.transform.position).normalized;
                //apply force
                print("hit");

                collision.gameObject.GetComponent<PlayerController>().GotHit(direction, forceApplied);

                ExecuteAfterSeconds(1, () => thrownFrom = null);


            }

        }
    }



}
