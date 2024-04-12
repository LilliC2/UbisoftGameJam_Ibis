using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnMannager : Singleton<DespawnMannager>
{
    public float itemAliveTime = 20;
    [SerializeField] SeagullControllerMannager seagullControllerMannager;
    [SerializeField] List<GameObject> despawnList = new List<GameObject>();

    



    IEnumerator Start()
    {
        seagullControllerMannager = _SC.GetComponentInChildren<SeagullControllerMannager>();
        while (true)
        {
            yield return new WaitForSeconds(1f); // Adjust the delay as needed
            foreach (GameObject obj in despawnList)
            {
                TrashItem trashItem = obj.GetComponent<TrashItem>();
                if (trashItem != null)
                {
                    trashItem.aliveTime -= 1f; // Subtract 1 from alive time
                    if (trashItem.aliveTime <= 0f)
                    {
                        Debug.Log(obj.name + " has expired!");
                        RemoveItemToDespawnList(obj);
                        seagullControllerMannager.SendItemToRandomList(obj); 
                        break;
                    }
                }
            }
        }
    }

    public void AddItemToDespawnList(GameObject obj)
    {

        despawnList.Add(obj);
        TrashItem trashItem = obj.GetComponent<TrashItem>();
       // Debug.Log(obj.name + " has been Added to list");
        trashItem.aliveTime = itemAliveTime;
    }

    public void RemoveItemToDespawnList(GameObject obj)
    {
        despawnList.Remove(obj);
        //Debug.Log(obj.name + " has been removed from list");
    }
}

