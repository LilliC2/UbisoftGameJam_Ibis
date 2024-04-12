using UnityEngine;

public class MatchRotation : MonoBehaviour
{
    [SerializeField] private GameObject targetObject; // The object whose rotation to copy

    private void Update()
    {
        if (targetObject != null)
        {
            // Copy the local rotation of the target object
            transform.localRotation = targetObject.transform.localRotation;
        }
        else
        {
            Debug.LogWarning("Target object is not set!");
        }
    }
}

