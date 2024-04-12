using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : Singleton<NPCSpawner>
{
    [Header("Objs")]
    public GameObject[] npcTypes;
    public Transform[] spawnPoints;
    public Transform fountainPoint;
    public List<GameObject> npcList;
    [SerializeField] int maxNumOfNPCs;

    [Header("Travel To Destination")]
    public GameObject[] destinations;

    [Header("Spawn Controls")]
    public int spawnDelay = 2;
    public int spawnChance = 5;
    public int spawnValue;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CallSpawnHuman()
    {
        StartCoroutine(SpawnChance());
    }

    public IEnumerator SpawnChance()
    {
        print("spawn human");

        yield return new WaitForSeconds(spawnDelay);
        spawnValue = Random.Range(0, 10);

        if(npcList.Count != maxNumOfNPCs)
        {
            if (spawnChance > spawnValue)
            {
                SpawnNPC();
            }
            StartCoroutine(SpawnChance());
        }

    }

    public void SpawnNPC()
    {
        int npcNumber = Random.Range(0, npcTypes.Length);
        int spawnPoint = Random.Range(0, spawnPoints.Length);
        GameObject npc = Instantiate(npcTypes[npcNumber], spawnPoints[spawnPoint].position, transform.rotation, transform);
        npcList.Add(npc);
    }

    public Vector3 GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
    }

    //public Vector3 GetRandomPoints()
    //{
    //    return randomPoints[Random.Range(0, randomPoints.Length)].transform.position;
    //}

    public Vector3 SetFountainLocation()
    {
        return fountainPoint.transform.position;
    }
}
