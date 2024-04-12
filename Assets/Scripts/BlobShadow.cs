using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobShadow : MonoBehaviour
{
    public GameObject shadow;
    [SerializeField] RaycastHit hit;
    [SerializeField] float offset;

    private void FixedUpdate()
    {
        Ray downRay = new Ray(new Vector3(this.transform.position.x, this.transform.position.y - offset, this.transform.position.z), -Vector3.up);

        //gets the hit from the raycast and converts it int a vector 3
        Vector3 hitPosition = hit.point;
        //transofrms the shadow to the location
        shadow.transform.position = hitPosition;
        shadow.transform.rotation = Quaternion.identity;

        //Casts a ray stright downwards. reads back where it lands

        if (Physics.Raycast(downRay,out hit))
        {
           // print(hit.transform);
        }
    }
}
