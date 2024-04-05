using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum NPCTyping { Casual, Runner, Police, Wanderer}

public enum NPCActions { Fountain, Walking, Running, Still, Scared, Bin}

public class NPCBehaviour : GameBehaviour
{
    [Header("Points")]
    public Vector3 nextTarget;

    [Header("AI")]
    public NavMeshAgent agent;
    public float mySpeed;
    public float myDelay = 1;
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
        //agent.SetDestination(_NPC.SetFountainLocation());
        nextTarget = _NPC.GetRandomSpawnPoint();
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
        }

        yield return new WaitForSeconds(myDelay);

        StartCoroutine(Actions());
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Fountain"))
    //    {
    //        ExecuteAfterSeconds(myDelay, () => MoveToNextPoint());
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fountain"))
        {
            print("hit");
            myActions = NPCActions.Walking;
            ExecuteAfterSeconds(myDelay, () => MoveToNextPoint());
        }
    }

    void MoveToNextPoint()
    {
        agent.SetDestination(nextTarget);
    }
}
