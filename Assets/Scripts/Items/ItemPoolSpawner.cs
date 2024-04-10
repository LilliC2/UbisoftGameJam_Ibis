using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPoolSpawner : MonoBehaviour
{

    [SerializeField] GameObject ItemToSpawn;
    [SerializeField] ItemList itemList;
    [SerializeField] int ItemsToSpawn = 5;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ItemsToSpawn; i++)
        {
            SpawnItem();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnItem()
    {
        GameObject newItem = Instantiate(ItemToSpawn, gameObject.transform);
        itemList.instantiatedItems.Add(newItem);
        newItem.SetActive(false);
    }
}
