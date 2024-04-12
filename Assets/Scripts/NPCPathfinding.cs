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
    [SerializeField] float dropTrashDelayMin;
    [SerializeField] float dropTrashDelayMax;
    NavMeshAgent agent;
    public enum BehaviourStates { Patrol, TravelToDestination, RunFromIbis }
    public BehaviourStates behaviourStates;
    Animator animator;

    [Header("Patrol")]
    bool hasDestination;
    [SerializeField] Vector3 currentDestination;

    [Header("Run From Ibis")]
    GameObject ibis;

    [Header("Drop Trash")]
    [SerializeField] GameObject dropTrashGO;
    GameObject itemToDrop;

    VFXManager vFXManager;
    [SerializeField] Transform particalTransform;

    // Start is called before the first frame update
    void Start()
    {
        vFXManager = _VFXM.GetComponentInChildren<VFXManager>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        currentDestination = SearchPatrolPoint();
        UpdateAgentSpeed(noramlSpeed);
        ExecuteAfterSeconds(3, () => StartCoroutine(DropTrash()));
    }

    void UpdateAgentSpeed(float speed)
    {
        agent.speed = speed;

    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Speed", agent.velocity.magnitude);
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

    IEnumerator DropTrash()
    {
        if(behaviourStates != BehaviourStates.RunFromIbis)
        {
            agent.isStopped = true;

            //animation
            //print("trigger animation");
            var itemPool = _IS.objectPools[Random.Range(0, _IS.objectPools.Length)];
            itemToDrop = itemPool.GetComponent<ItemPoolMannager>().GetItem(dropTrashGO.transform.position);
            if(itemToDrop != null)
            {
                itemToDrop.GetComponent<TrashItem>().readyToBin = false;
                itemToDrop.GetComponent<TrashItem>().PickedUp(dropTrashGO);
                itemToDrop.GetComponent<TrashItem>().lastToHold = gameObject;
                animator.SetTrigger("ThrowTrash");

            }
            



        }

        yield return new WaitForSeconds(Random.Range(dropTrashDelayMin,dropTrashDelayMax));

        StartCoroutine(DropTrash());

    }

    public void DropTrashAnimEvent()
    {
        //print("drop trash from anim event");
        if(itemToDrop != null) itemToDrop.GetComponent<TrashItem>().Dropped();

        itemToDrop = null;
        agent.isStopped = false;
        
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
            print("HONKING");
            ibis = other.gameObject;
            vFXManager.SpawnParticle(1, particalTransform);
            behaviourStates = BehaviourStates.RunFromIbis;
        }
    }
}
