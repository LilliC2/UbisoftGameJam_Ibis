using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemToBinScript : GameBehaviour
{
    [SerializeField] Transform binTpTransform;
    BinMannager binMannager;

    private void Start()
    {
        binMannager = GetComponentInParent<BinMannager>();
    }

    private void OnTriggerEnter(Collider other)
    {

        other.gameObject.TryGetComponent<TrashItem>(out TrashItem trashItemScript);
        if(trashItemScript != null)
        {
            print(trashItemScript.lastToHold);

            if (trashItemScript.lastToHold == null || trashItemScript.lastToHold.name.Contains("NPC")) BinIt(other);
            else if (trashItemScript.lastToHold == binMannager.assigedPlayer && trashItemScript.lastToHold.name.Contains("Player"))
            {
                print("Detected");
                if (other.transform.tag == "SmallTrash" || other.transform.tag == "MediumTrash" || other.transform.tag == "BigTrash")
                {
                    BinIt(other);
                    trashItemScript.lastToHold.GetComponent<PlayerController>().UpdateSpeed();
                }
            }

        }

        //if (trashItemScript.lastToHold.name.Contains("NPC"))
        //{
        //    if (trashItemScript.readyToBin) BinIt(other);
        //}




    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == _GM.pickUpProps_and_HeldItemsMask)
        {
            TrashItem trashitem = other.gameObject.GetComponent<TrashItem>();
            if (trashitem.readyToBin) BinIt(other);
        }
    }

    void BinIt(Collider other)
    {
        if (other.transform.tag == "SmallTrash" || other.transform.tag == "MediumTrash" || other.transform.tag == "BigTrash")
        {
            print("TrashInZone");
            other.transform.position = binTpTransform.position;
            TrashItem trashitem = other.gameObject.GetComponent<TrashItem>();
            if (trashitem != null)
            {
                trashitem.Dropped();
                trashitem.readyToBin = false;
            }
            else
            {
                Debug.LogWarning("TrashItem component not found on collided object.");
            }
        }
    }
}
