using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDayManager : MonoBehaviour
{
    public float timeOfDayCycleDuration = 120.0f; // Duration of the entire day-night cycle in seconds
    public Transform sunTransform; // Assign the directional light's transform here

    private float currentTimeOfDay = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the new time of day based on the cycle duration
        currentTimeOfDay += Time.deltaTime / timeOfDayCycleDuration;

        // Keep the timeOfDay value between 0 and 1
        if (currentTimeOfDay > 1.0f)
        {
            currentTimeOfDay -= 1.0f;
        }

        // Update the sun's rotation to simulate changing time of day
        float angle = currentTimeOfDay * 360.0f; // Convert time to angle
        sunTransform.rotation = Quaternion.Euler(new Vector3(angle, 0, 0));
    }
}
