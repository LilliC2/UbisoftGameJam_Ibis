using UnityEngine;
using System.Collections.Generic;


public class SeagullController : MonoBehaviour
{
    [SerializeField] GameObject trackingObject;  //source for bird to follow
    [SerializeField] GameObject followerObj;    //smooths transform for bird
    [SerializeField] Transform pickupPoint;
    [SerializeField] Transform mouthTransform;
    [SerializeField] List<Transform> movePoints = new List<Transform>();
    [SerializeField] List<GameObject> birdCollectList = new List<GameObject>();
    [SerializeField] float moveSpeed = 5f; // Speed of movement
    [SerializeField] float followSpeed = 5f; // Speed of following
    private int currentPointIndex = 0; // Index of the current point
    private bool isMoving = false; // Flag to track whether movement is in progress
    [SerializeField] Animator seaGullAnimator;


    public void StartFlight()
    {

        //print(birdCollectList.Count);
        if (birdCollectList.Count != 0 && !isMoving)
        {
            //print("starting movie");
            StartMovement(birdCollectList[0]);
        }
    }


    // Call this function to start the movement
    public void StartMovement(GameObject location)
    {
        if (movePoints.Count == 0)
        {
            Debug.LogWarning("No move points assigned!");
            return;
        }

        transform.position = location.transform.position;
        transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

        trackingObject.transform.position = movePoints[0].transform.position;
        followerObj.transform.position = movePoints[0].transform.position;

        // Set flag to indicate movement is in progress
        isMoving = true;
        // Start the movement
        MoveToNextPoint();
    }

    void Update()
    {
        // Check if movement is in progress
        if (isMoving)
        {
            // Move towards the current target point
            Transform targetPoint = movePoints[currentPointIndex];
            trackingObject.transform.position = Vector3.MoveTowards(trackingObject.transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

            //print(currentPointIndex);
            // Check if the second point is reached
            if (currentPointIndex >= 3)
            {
                if(birdCollectList[0] != null) birdCollectList[0].transform.position = mouthTransform.transform.position;

            }

            // Check if the object has reached the target point
            if (Vector3.Distance(trackingObject.transform.position, targetPoint.position) < 0.01f)
            {
                // Move to the next point
                MoveToNextPoint();
                seaGullAnimator.SetInteger("FlyState", currentPointIndex);


            }
        }

        // Follow and look at the first game object smoothly
        if (followerObj != null)
        {
            Vector3 desiredPosition = Vector3.Lerp(followerObj.transform.position, trackingObject.transform.position, Time.deltaTime * followSpeed);
            followerObj.transform.position = desiredPosition;

            Quaternion desiredRotation = Quaternion.Lerp(followerObj.transform.rotation, Quaternion.LookRotation(trackingObject.transform.position - followerObj.transform.position), Time.deltaTime * followSpeed);
            followerObj.transform.rotation = desiredRotation;
        }
    }

    // Function to move to the next point
    private void MoveToNextPoint()
    {
        currentPointIndex = (currentPointIndex + 1) % movePoints.Count;
        // Check if all points have been visited
        if (currentPointIndex == 0)
        {
            // Stop movement
            isMoving = false;
            birdCollectList[0].SetActive(false);
            print("Item Removed From Collect List from here");
            birdCollectList.RemoveAt(0);
            StartFlight();
        }
    }


    public void AddItemToBirdCollectionList(GameObject obj)
    {

        //Debug.Log("AddItemToCollectList Called");
        if (obj != null && obj.activeSelf)
        {
            birdCollectList.Add(obj);
            //Debug.Log("Item added to collect list: " + obj.name);
        }
        else
        {
            //Debug.LogWarning("Attempted to add null or inactive object to collect list.");
        }
        StartFlight();
    }


    public void RemoveItemToCollectList(GameObject obj)
    {
        birdCollectList.Remove(obj);
        //print("Item Removed From Collect List from here");
    }

}