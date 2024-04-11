using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItem : GameBehaviour
{
    public GameObject holdPos;
    public GameObject lastToHold;
    Transform poolParent;
    GameObject thrownFrom;
    Rigidbody rb;
    public float forceApplied = 500;
    bool addForce;
    public bool readyToBin = true;

    public float aliveTime = 60;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        poolParent = gameObject.transform.root;
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
        gameObject.transform.parent = player_holdPos.transform;
        lastToHold = player_holdPos.transform.root.gameObject;
        if(rb == null) rb = GetComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezeAll;

        transform.position = holdPos.transform.position;

        //rb.Sleep();
        _DM.RemoveItemToDespawnList(gameObject);

        _SC.RemoveItemToCollectList(gameObject);

    }

    public void Dropped()
    {

        gameObject.transform.parent = poolParent;

        readyToBin = true;
        holdPos = null;
        // rb.WakeUp();
        rb.constraints = RigidbodyConstraints.None;
        _DM.AddItemToDespawnList(gameObject);

        //_BM.AddToList(gameObject);

    }

    public void Thrown(GameObject player)
    {
        gameObject.transform.parent = poolParent;

        print("Called thrown on object for " + gameObject.name);
        holdPos = null;
        rb.constraints = RigidbodyConstraints.None;
        thrownFrom = player;
        _DM.RemoveItemToDespawnList(gameObject);

        //_BM.AddToList(gameObject);


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
