using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : GameBehaviour
{
    
    [SerializeField] List<GameObject> npc;
    GameObject currentNpc;
    [SerializeField] float movementSpeed;
    [SerializeField] float minTime;
    [SerializeField] float maxTime;

    void Start()
    {
        SpawnNPC();
    }

    
    void Update()
    {
        //moves the current NPC forward
        if(currentNpc != null)
        {
            currentNpc.transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
    }

    void SpawnNPC()
    {
        //To flip the NPCs the correct way around
        currentNpc = Instantiate(npc[Random.Range(0, npc.Count)], gameObject.transform.position, Quaternion.identity);
        
        //print(gameObject.transform.rotation.y);
        if (gameObject.transform.localEulerAngles.y == 270)
        {
            currentNpc.transform.localEulerAngles = new Vector3(-90, 180, 90);
        }
        else currentNpc.transform.localEulerAngles = new Vector3(-90, 90, 0);


        //After x amount of seconds, will call next code which is DeleteNpc()
        ExecuteAfterSeconds(Random.Range(minTime, maxTime), ()=> DeleteNpc());

    }

    void DeleteNpc()
    {
        Destroy(currentNpc);
        SpawnNPC();
    }


}
