using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : GameBehaviour
{

    [SerializeField]
    Ease overworldCamEase;
    bool overworldCameraEase = false;

    [SerializeField] float zAdjustments;
    [SerializeField] float xAdjustments;
    [SerializeField] float yAdjustments;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
