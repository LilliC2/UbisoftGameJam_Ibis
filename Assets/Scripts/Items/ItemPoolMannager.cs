using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPoolMannager : MonoBehaviour
{
    [SerializeField] ItemList itemList;
    [SerializeField] ItemSpawner itemToSpawn;
    [SerializeField] ItemPoolSpawner itemPoolSpawner;

    public void GetItem(Vector3 spawnPosition)
    {
        bool foundInactiveObject = false;

        foreach (GameObject item in itemList.instantiatedItems)
        {
            if (!item.activeSelf)
            {
                foundInactiveObject = true;
                itemToSpawn.SpawnItem(item, spawnPosition);
                break;
            }
        }

        if (!foundInactiveObject)
        {
            itemPoolSpawner.SpawnItem();
            GetItem(spawnPosition);
        }
    }
}
