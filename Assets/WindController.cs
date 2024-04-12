using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float lerpDuration = 15f; // Duration of the rotation lerp
    [SerializeField] float updateInterval = 30f; // Interval to pick a new rotation
    [SerializeField] float elapsedTime = 0f; // Elapsed time since last rotation update
    [SerializeField] Quaternion targetRotation; // Target rotation for lerping
    [SerializeField] Quaternion startRotation; // Initial rotation before lerping

    private void Start()
    {
        // Start the initial rotation
        PickNewRotation();
    }

    private void Update()
    {
        // Update the elapsed time
        elapsedTime += Time.deltaTime;

        // If it's time to pick a new rotation
        if (elapsedTime >= updateInterval)
        {
            // Reset elapsed time
            elapsedTime = 0f;

            // Pick a new rotation
            PickNewRotation();
        }

        // Lerp towards the target rotation
        transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / lerpDuration);
    }

    private void PickNewRotation()
    {
        // Store the current rotation as the start rotation
        startRotation = transform.rotation;

        // Pick a random y rotation
        float randomYRotation = Random.Range(0f, 360f);

        // Create a new rotation with the random y rotation
        targetRotation = Quaternion.Euler(0f, randomYRotation, 0f);
    }
}
