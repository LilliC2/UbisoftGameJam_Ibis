using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPoolInactiveMannager : MonoBehaviour
{
    //public List<GameObject> itemList; // List of GameObjects to track

    public ItemList itemList;

    [SerializeField] private float deletionTimeThreshold = 10f; // Threshold in seconds for deletion
    [SerializeField] int keptItems = 2;

    void Update()
    {
        // Start tracking inactive time and delete objects if needed
        CheckInactiveObjects();
    }

    void CheckInactiveObjects()
    {
        for (int i = keptItems; i < itemList.instantiatedItems.Count; i++) // Start from the 6th item in the list
        {
            GameObject item = itemList.instantiatedItems[i];

            if (!item.activeSelf) // If the item is inactive
            {
                if (Time.time - item.GetComponent<InactiveTimeTracker>().lastActiveTime >= deletionTimeThreshold)
                {
                    Debug.Log("Deleting object: " + item.name);
                    Destroy(item);
                    itemList.instantiatedItems.RemoveAt(i); // Remove the item from the list
                    i--; 
                }
            }
            else // If the item is active, update its last active time
            {
                item.GetComponent<InactiveTimeTracker>().lastActiveTime = Time.time;
            }
        }
    }
}
