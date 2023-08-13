using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Behavior_FollowPlayer : MonoBehaviour
{
    public float walkingSpeed = 3.5f;
    public float runningSpeed = 6.5f;
    private NavMeshAgent npcNavMeshAgent;
    public Transform playerTransform;
    public float allowedDistance;
    public Transform raycastSource;
    public float raycastRange;
    public bool canFollow = true;
    private float pathLength;
    private InterfaceManager ui;

    private void Start()
    {
        npcNavMeshAgent = GetComponent<NavMeshAgent>();
        ui = InterfaceManager.instance;
    }

    private void Update()
    {
        if (!ui.inDialogue)
        {
            if (canFollow)
            {
                npcNavMeshAgent.destination = playerTransform.position;

                float debugDuration = 2.0f;
                Ray ray = new Ray(raycastSource.position, raycastSource.forward);
                RaycastHit hitData;
                Debug.DrawRay(ray.origin, ray.direction * raycastRange, Color.red, debugDuration);
                if (Physics.Raycast(ray, out hitData, raycastRange))
                {
                    if (hitData.collider.CompareTag("Player"))
                    {
                        gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
                    }
                }

                CalculatePathLength();

                if (pathLength >= 10f)
                {
                    npcNavMeshAgent.speed = runningSpeed;
                }
                else
                {
                    npcNavMeshAgent.speed = walkingSpeed;
                }
            }
        }
        else
        {
            gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
        }
    }

    private void CalculatePathLength()
    {
        NavMeshPath path = new NavMeshPath();
        if (npcNavMeshAgent.CalculatePath(playerTransform.position, path))
        {
            pathLength = 0f; // Reset pathLength for each calculation

            for (int i = 0; i < path.corners.Length - 1; i++)
            {
                pathLength += Vector3.Distance(path.corners[i], path.corners[i + 1]);
            }

            Debug.Log("Path length: " + pathLength);
        }
    }
}
