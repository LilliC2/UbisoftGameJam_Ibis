using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItem : GameBehaviour
{
    public GameObject holdPos;
    Rigidbody rb;
    public float forceApplied = 500;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (rb.velocity.magnitude > 2f && collision.gameObject.CompareTag("Player"))
        {            
            //apply force
            print("hit");
            var rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(0, forceApplied, 0);

        }
    }
}
