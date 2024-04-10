using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemToBinScript : MonoBehaviour
{
    [SerializeField] Transform binTpTransform;

    private void OnTriggerEnter(Collider other)
    {
        print("Detected");
        if (other.transform.tag == "SmallTrash" || other.transform.tag == "MediumTrash" || other.transform.tag == "BigTrash")
        {
            print("TrashInZone");
            other.transform.position = binTpTransform.position;
            TrashItem trashitem = other.gameObject.GetComponent<TrashItem>();
            if (trashitem != null)
            {
                trashitem.Dropped();
            }
            else
            {
                Debug.LogWarning("TrashItem component not found on collided object.");
            }
        }
    }
}
