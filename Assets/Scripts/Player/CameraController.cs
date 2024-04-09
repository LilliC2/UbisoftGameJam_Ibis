using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : GameBehaviour
{

    [SerializeField]
    Ease overworldCamEase;
    bool overworldCameraEase = false;
    [SerializeField] float zoomMin;
    [SerializeField] float zoomMax;
    [SerializeField] float zoomSpeed;
    [SerializeField] float orthoSize;
    
    float prevLargDis;

    Camera cam;

    [SerializeField] float zAdjustments;
    [SerializeField] float xAdjustments;
    [SerializeField] float yAdjustments;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        orthoSize = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = new();

        foreach (var item in _GM.playerGameObjList)
        {
            position += item.transform.position;
        }

        position /= _GM.playerGameObjList.Count;

        gameObject.transform.position = new Vector3(position.x + xAdjustments, yAdjustments, position.z + zAdjustments);

        print(CheckIfAllPlayersAreVisible());


        if (!CheckIfAllPlayersAreVisible())
        {
            ChangeCameraSize();

        }

    }

    void ChangeCameraSize()
    {
        //determine if we need to go larger or smaller
        float largestDistance = 0;
        //get the largest distance between players
        for (int i = 0; i < _GM.playerGameObjList.Count; i++)
        {
            for (int v = 0; v < _GM.playerGameObjList.Count; v++)
            {
                if (Vector3.Distance(_GM.playerGameObjList[i].transform.position, _GM.playerGameObjList[v].transform.position) > largestDistance)
                {
                    largestDistance = Vector3.Distance(_GM.playerGameObjList[i].transform.position, _GM.playerGameObjList[v].transform.position);
                }
            }
        }


        //go bigger
        if (!CheckIfAllPlayersAreVisible())
        {
            orthoSize += zoomSpeed * Time.deltaTime;
        }
        //else
        //{

        //    //go smaller
        //    if (largestDistance < 25f)
        //    {
        //        orthoSize -= zoomSpeed * Time.deltaTime;

        //        if (prevLargDis != largestDistance && largestDistance < prevLargDis)
        //        {
        //            orthoSize = Mathf.Clamp(orthoSize, zoomMin, zoomMax);
        //            cam.orthographicSize = orthoSize;
        //        }
        //    }
        //}



        prevLargDis = largestDistance;

        print(largestDistance);
    }

    bool CheckIfAllPlayersAreVisible()
    {
        bool allPlayersAreVisible = true;

        foreach (var player in _GM.playerGameObjList)
        {
            if (!player.GetComponentInChildren<SkinnedMeshRenderer>().isVisible) allPlayersAreVisible = false;
        }

        return allPlayersAreVisible;
    }
}
