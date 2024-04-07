using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum NPCTyping { Casual, Runner, Slow, Wanderer, Garbo}

public enum NPCActions { Fountain, Walking, Running, Still, Scared, Bin, Wander}

public class NPCBehaviour : GameBehaviour
{
    [Header("Pathfinding")]
    public NavMeshAgent agent;
    public Vector3 nextTarget;          //The location the NPC will go to after reaching the fountain
    public Vector3 endPoint;            //The location where the NPC ceased to exist
    public bool hasReeachedFauntain;    //Check if npc has reach the center of the map

    [Header("Stats")]
    public float mySpeed = 50;               //Speed
    public float myDelay = 1;           //Delay between behaviour switch

    [Header("Action State")]
    public NPCTyping myType;            //Determinds the stats of the NPC
    public NPCActions myActions;        //Determinds the actions of the NPC
    public bool ibisVunerability;       //Check if npc can be affected by ibis
    public float ibisDelay = 0.5f;      //Invunerability periode between ibis's scream
    public int actionNumber;            //Action the npc will make

    // Start is called before the first frame update
    void Start()
    {
        SetupAI();
        hasReeachedFauntain = false;
        ibisVunerability = true;
        //agent.SetDestination(_NPC.SetFountainLocation());
        nextTarget = endPoint = _NPC.GetRandomSpawnPoint();
        StartCoroutine(Actions());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetupAI()
    {
        switch (myType)
        {
            case NPCTyping.Casual:
                agent.speed = mySpeed;
                myDelay = 2;
                break;
        }
    }

    IEnumerator Actions()
    {
        switch (myActions)
        {
            case NPCActions.Fountain:
                agent.SetDestination(_NPC.SetFountainLocation());
                break;
            case NPCActions.Walking:
                MoveToNextPoint();
                break;
            case NPCActions.Still:
                actionNumber = Random.Range(0, 4);
                ExecuteAfterSeconds(myDelay, () => RandomBehavior());
                break;
            case NPCActions.Wander:
                agent.SetDestination(_NPC.GetRandomPoints());
                break;
            case NPCActions.Scared:
                ExecuteAfterSeconds (myDelay + 2, ()=> ChangeBehavior(NPCActions.Walking));
                break;
        }

        yield return new WaitForSeconds(myDelay);

        StartCoroutine(Actions());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fountain"))
        {
            print("hit");
            hasReeachedFauntain = true;
            myActions = NPCActions.Walking;

            ExecuteAfterSeconds(myDelay + 2, () => RandomBehavior());
        }

        if (other.CompareTag("BinBitchin") && ibisVunerability)
        {
            print("Ibised");
            myActions = NPCActions.Scared;
            Vector3 collisionPoint = other.ClosestPoint(transform.position);
            Vector3 oppositeDirection = transform.position - collisionPoint;
            Vector3 newDestination = transform.position + oppositeDirection;
            agent.SetDestination(newDestination);

            //actionNumber = Random.Range(0, 4);
            //if (actionNumber == 0) { myActions = NPCActions.Still; }
            //if (actionNumber == 1) { myActions = NPCActions.Walking; }
            //if (actionNumber == 2) { myActions = NPCActions.Wander; }
        }
    }

    public void ChangeBehavior(NPCActions actions)
    {
        myActions = actions;
    }

    public void RandomBehavior()
    {
        actionNumber = Random.Range(0, 4);
        if (actionNumber == 0) { myActions = NPCActions.Still; }
        if (actionNumber == 1) { myActions = NPCActions.Walking; }
        if (actionNumber == 2) { myActions = NPCActions.Wander; }
    }

    void MoveToNextPoint()
    {
        agent.SetDestination(nextTarget);
    }

    void MoveToRandomPoint()
    {
        agent.SetDestination(_NPC.GetRandomPoints());
    }
}
