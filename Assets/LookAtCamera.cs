using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private void Update()
    {
        // Get the direction from this object to the camera
        Vector3 directionToCamera = Camera.main.transform.position - transform.position;

        // Calculate the angle only on the z-axis
        float angleToCamera = Mathf.Atan2(directionToCamera.y, directionToCamera.x) * Mathf.Rad2Deg;

        // Apply the rotation only on the z-axis
        transform.rotation = Quaternion.Euler(0f, 0f, angleToCamera);
    }
}