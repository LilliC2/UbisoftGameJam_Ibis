using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Singleton<ItemSpawner>
{
    public GameObject [] objectPools;
    [SerializeField] private bool spawnObject = true;
    [SerializeField] List<GameObject> foodToSpawnPools;
    int lastCatch = -1;

    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float padding;
    [SerializeField] private float ySpawn;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;

    DespawnMannager despawnMannager;


    private void Start()
    {
       despawnMannager = _GM.GetComponentInChildren<DespawnMannager>();
        //CalculateMinMaxX();
        //StartCoroutine(Spawn());
        InitalTrashSpawn();
    }

    void InitalTrashSpawn()
    {
        for (int i = 0; i < 20; i++)
        {
            var objPool = objectPools[Random.Range(0, objectPools.Length)];
            Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), ySpawn, Random.Range(minZ, maxZ));
            objPool.GetComponent<ItemPoolMannager>().GetItem(spawnPos);
        }
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

    public void SpawnItem(GameObject itemToSpawn, Vector3 spawnPos)
    {
        //when humans throw trash, change spawnPosition to parameter instead of random

        float randomX = Random.Range(minX, maxX);
        //Vector3 spawnPosition = new Vector3(randomX, ySpawn, zSpawn);
        itemToSpawn.transform.position = spawnPos;
        itemToSpawn.SetActive(true);
        despawnMannager.AddItemToDespawnList(itemToSpawn);

    }

}

