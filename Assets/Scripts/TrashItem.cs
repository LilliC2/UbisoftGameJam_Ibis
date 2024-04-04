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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(holdPos != null)
            transform.position = holdPos.transform.position;

    }

    public void PickedUp(GameObject player_holdPos)
    {
        holdPos = player_holdPos;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        //rb.Sleep();
    }

    public void Dropped()
    {
        holdPos = null;
       // rb.WakeUp();
        rb.constraints = RigidbodyConstraints.None;
    }

    public void Thrown(GameObject player)
    {
        print("Called thrown on object for " + gameObject.name);
        holdPos = null;
        rb.constraints = RigidbodyConstraints.None;
        thrownFrom = player;
        print(player);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (rb.velocity.magnitude > 2f &&collision.gameObject.CompareTag("Player"))
        {
            if(collision.gameObject != thrownFrom)
            {
                var direction = (collision.gameObject.transform.position - gameObject.transform.position).normalized;
                //apply force
                print("hit");
                var rb = collision.gameObject.GetComponent<Rigidbody>();

                rb.isKinematic = false;
                rb.AddForce(direction * forceApplied, ForceMode.Force);

                ExecuteAfterSeconds(1, () => ResetRB(rb));
            }
 
        }
    }

    void ResetRB(Rigidbody rb)
    {
        rb.isKinematic = true;
        thrownFrom = null;
    }


}
