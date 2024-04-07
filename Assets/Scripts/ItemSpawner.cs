using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private bool spawnObject = true;
    [SerializeField] List<GameObject> foodToSpawnPools;
    int lastCatch = -1;

    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float padding;
    [SerializeField] private float ySpawn;
    [SerializeField] private float zSpawn;

    [SerializeField] DespawnMannager despawnMannager;


    private void Start()
    {
        CalculateMinMaxX();
        StartCoroutine(Spawn());
    }

    void CalculateMinMaxX()
    {
        float screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize; // Half of the screen width in world units
        minX = -screenHalfWidth + padding;
        maxX = screenHalfWidth - padding;
    }

    IEnumerator Spawn()
    {
        while (spawnObject == true)
        {
            int rand = Random.Range(0, foodToSpawnPools.Count - 1);
            int rand2 = Random.Range(0, 4);
            if (rand2 < 1 && lastCatch != -1)
                rand = lastCatch;

            GameObject gameobject = foodToSpawnPools[rand];
            ItemPoolMannager itemPoolMannger = gameobject.GetComponent<ItemPoolMannager>();
            itemPoolMannger.GetItem();
            //lastCatch = rand;

            yield return new WaitForSeconds(5f);
        }
    }

    public void SpawnItem(GameObject itemToSpawn)
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, ySpawn, zSpawn);
        itemToSpawn.SetActive(true);
        itemToSpawn.transform.position = spawnPosition;
        despawnMannager.AddItemToDespawnList(itemToSpawn);
        

    }

    public void UpdateCurrentItem(GameObject currentItem)
    {
        lastCatch = FindObjectIndexWithTag(currentItem.transform.tag);
    }

    int FindObjectIndexWithTag(string tag)
    {
        for (int i = 0; i < foodToSpawnPools.Count; i++)
        {
            if (foodToSpawnPools[i].CompareTag(tag))
            {
                return i; // Return the index of the object with the specified tag
            }
        }

        return -1; // Return -1 if the object with the specified tag is not found
    }
}

