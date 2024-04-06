using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinPlayerCollisionScript : MonoBehaviour
{
    public GameObject xTrans;
    public GameObject zTrans;
    public GameObject BinRoot;

    // Smoothing factor
    public float smoothness = 5f;

    private void FixedUpdate()
    {
        LookAtAverage(xTrans, zTrans);
    }

    public void LookAtAverage(GameObject _x, GameObject _z)
    {
        Quaternion xRotation = Quaternion.Euler(_x.transform.rotation.eulerAngles.x, 0f, 0f);
        Quaternion zRotation = Quaternion.Euler(0f, 0f, _z.transform.rotation.eulerAngles.z);

        // Combine rotations while keeping y-component unchanged
        Quaternion resultRotation = xRotation * zRotation;

        // Smoothly interpolate between the current rotation and the target rotation
        Quaternion smoothedRotation = Quaternion.Lerp(BinRoot.transform.rotation, resultRotation, smoothness * Time.deltaTime);

        // Apply the smoothed rotation to BinRoot
        BinRoot.transform.rotation = smoothedRotation;
    }
}
