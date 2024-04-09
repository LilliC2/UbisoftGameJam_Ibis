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

        ChangeCameraSize();

        if (!CheckIfAllPlayersAreVisible())
        {
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

        if(largestDistance > 22.5f) //go bigger
        {
            if(!CheckIfAllPlayersAreVisible()) orthoSize += zoomSpeed * Time.deltaTime;
        }
        else if(largestDistance < 22.5f && largestDistance > 5)
            orthoSize -= zoomSpeed * Time.deltaTime;

        orthoSize = Mathf.Clamp(orthoSize, zoomMin, zoomMax);
        cam.orthographicSize = orthoSize;

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
