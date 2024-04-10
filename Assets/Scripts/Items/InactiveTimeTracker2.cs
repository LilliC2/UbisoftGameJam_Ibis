using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveTimeTracker2 : MonoBehaviour
{
    public float lastActiveTime; // Time when the game object was last active

    void OnEnable()
    {
        lastActiveTime = Time.time; // Initialize the last active time when the game object becomes active
    }
}

