using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Singleton<ItemSpawner>
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
        //CalculateMinMaxX();
        //StartCoroutine(Spawn());
    }

    public void Update()
    {

    }

    //void CalculateMinMaxX()
    //{
    //    float screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize; // Half of the screen width in world units
    //    minX = -screenHalfWidth + padding;
    //    maxX = screenHalfWidth - padding;
    //}

    //IEnumerator Spawn()
    //{
    //    while (spawnObject == true)
    //    {
    //        int rand = Random.Range(0, foodToSpawnPools.Count);
    //        int rand2 = Random.Range(0, 4);
    //        if (rand2 < 1 && lastCatch != -1)
    //            rand = lastCatch;

    //        GameObject gameobject = foodToSpawnPools[rand];
    //        ItemPoolMannager itemPoolMannger = gameobject.GetComponent<ItemPoolMannager>();
    //        itemPoolMannger.GetItem();
    //        //lastCatch = rand;

    //        yield return new WaitForSeconds(5f);
    //    }
    //}

    public void SpawnItem(GameObject itemToSpawn,Vector3 spawnPosition)
    {
        //when humans throw trash, change spawnPosition to parameter instead of random

        float randomX = Random.Range(minX, maxX);
        //Vector3 spawnPosition = new Vector3(randomX, ySpawn, zSpawn);
        itemToSpawn.SetActive(true);
        itemToSpawn.transform.position = spawnPosition;
        despawnMannager.AddItemToDespawnList(itemToSpawn);

    }

}

