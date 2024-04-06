using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum NPCTyping { Casual, Runner, Police, Wanderer}

public enum NPCActions { Fountain, Walking, Running, Still, Scared, Bin, Wander}

public class NPCBehaviour : GameBehaviour
{
    [Header("Points")]
    public Vector3 nextTarget;

    [Header("AI")]
    public NavMeshAgent agent;
    public float mySpeed;
    public float myDelay = 1;
    public bool hasReeachedFauntain;
    Vector3 endPoint;
    public int actionNumber;
    public NPCTyping myType;
    public NPCActions myActions;
    int patrolPoint = 0;        //Needed for linear patrol movement
    bool reverse = false;       //Needed for repeat patrol movement
    Transform startPos;         //Needed for repeat patrol movement
    Transform endPos;           //Needed for repeat patrol movement
    Transform moveToPos;

    // Start is called before the first frame update
    void Start()
    {
        hasReeachedFauntain = false;
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
                myDelay = 2;
                mySpeed = 10;
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
                if (actionNumber == 0) { myActions = NPCActions.Still; }
                if (actionNumber == 1) { myActions = NPCActions.Walking; }
                if (actionNumber == 2) { myActions = NPCActions.Wander; }
                break;
            case NPCActions.Wander:
                agent.SetDestination(_NPC.SetFountainLocation());
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

            actionNumber = Random.Range(0, 4);
            if(actionNumber == 0) { myActions = NPCActions.Still; }
            if(actionNumber == 1) { myActions = NPCActions.Walking; }
            if(actionNumber == 2) { myActions = NPCActions.Wander; }
            //ExecuteAfterSeconds(myDelay, () => MoveToNextPoint());
        }

        if (other.CompareTag("BinBitchin"))
        {
            print("Ibised");
            Vector3 collisionPoint = other.ClosestPoint(transform.position);
            Vector3 oppositeDirection = transform.position - collisionPoint;
            Vector3 newDestination = transform.position + oppositeDirection;
            agent.SetDestination(newDestination);

            actionNumber = Random.Range(0, 4);
            if (actionNumber == 0) { myActions = NPCActions.Still; }
            if (actionNumber == 1) { myActions = NPCActions.Walking; }
            if (actionNumber == 2) { myActions = NPCActions.Wander; }
            //ExecuteAfterSeconds(myDelay, () => MoveToNextPoint());
        }
    }

    void MoveToNextPoint()
    {
        agent.SetDestination(nextTarget);
    }
}
