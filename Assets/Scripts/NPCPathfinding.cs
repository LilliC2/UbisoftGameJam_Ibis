using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPCPathfinding : GameBehaviour
{
    [Header("Stats")]
    [SerializeField] float visionRange;
    [SerializeField] float noramlSpeed;
    [SerializeField] float runningSpeed;
    [SerializeField] float distanceFromIbis;
    NavMeshAgent agent;
    public enum BehaviourStates { Patrol, TravelToDestination, RunFromIbis }
    public BehaviourStates behaviourStates;

    [Header("Patrol")]
    bool hasDestination;
    [SerializeField] Vector3 currentDestination;

    [Header("Run From Ibis")]
    GameObject ibis;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentDestination = SearchPatrolPoint();
        UpdateAgentSpeed(noramlSpeed);
    }

    void UpdateAgentSpeed(float speed)
    {
        agent.speed = speed;

    }

    // Update is called once per frame
    void Update()
    {
        switch(behaviourStates)
        {
            case BehaviourStates.Patrol:

                if(!hasDestination)
                {
                    hasDestination = true;
                    currentDestination = SearchPatrolPoint(); //ExecuteAfterSeconds(Random.Range(10f, 15), () => 
                    agent.SetDestination(currentDestination);
                }
                if (Vector3.Distance(gameObject.transform.position, currentDestination) <= 1) hasDestination = false;

                break;
            case BehaviourStates.TravelToDestination:

                if (!hasDestination)
                {
                    hasDestination = true;

                    ExecuteAfterSeconds(Random.Range(10f, 15), () => currentDestination = SearchDestinationWalkPoint());
                    agent.SetDestination(currentDestination);

                }
                if (Vector3.Distance(gameObject.transform.position, currentDestination) <= 1)
                {
                    hasDestination = false;

                }

                break;
            case BehaviourStates.RunFromIbis:

                if (agent.speed != runningSpeed) UpdateAgentSpeed(runningSpeed);

                //calculate direction away from ibis
                if(Vector3.Distance(ibis.transform.position, gameObject.transform.position) < distanceFromIbis)
                {
                    Vector3 direction = transform.position - ibis.transform.position;
                    Vector3 runPos = transform.position + direction;

                    agent.SetDestination(direction);
                }
                else
                {
                    ibis = null;
                    behaviourStates = BehaviourStates.TravelToDestination;
                }
                break;
        }
    }

    Vector3 SearchDestinationWalkPoint()
    {

        return _NPC.destinations[Random.Range(0,_NPC.destinations.Length)].transform.position + Random.insideUnitSphere * 1;

    }

    Vector3 SearchPatrolPoint()
    {
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * visionRange;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomPoint, out hit, visionRange, NavMesh.AllAreas);
        Vector3 finalPos = hit.position;

        return finalPos;

        //Vector3 point;
        //Vector3 origin = _NPC.fountainPoint.transform.position + Random.insideUnitSphere * 50;
        //NavMeshHit hit;
        //NavMesh.SamplePosition(origin, out hit, 1, NavMesh.AllAreas);
        //point = hit.position;

        //return point;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BinBitchin"))
        {
            ibis = other.gameObject;
            behaviourStates = BehaviourStates.RunFromIbis;
        }
    }
}
