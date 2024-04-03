using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItem : GameBehaviour
{
    public GameObject holdPos;
    Rigidbody rb;

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
        rb.constraints = RigidbodyConstraints.FreezePosition;

    }

    public void Dropped()
    {
        holdPos = null;
        rb.constraints = RigidbodyConstraints.None;

    }
}
