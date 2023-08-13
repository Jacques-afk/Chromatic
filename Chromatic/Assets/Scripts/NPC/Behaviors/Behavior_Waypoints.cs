using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Behavior_Waypoints : MonoBehaviour
{
    //Create a list to store the transform of the waypoints
    private Transform[] waypoints;
    [SerializeField] private GameObject waypointParent;

    private InterfaceManager ui;

    private bool reachedDestination = false;

    private NavMeshAgent npcNavMeshAgent;

    private int waypointIndex = 0;

    public Transform questWait;

    private NPCScript currentNPC;

    private void Start()
    {
        ui = InterfaceManager.instance;
        //Get the transform of each waypoint in parent object, store it in a temp array
        Transform[] temp = waypointParent.GetComponentsInChildren<Transform>();
        //waypoints array with one less element (as we don't want the parent's transform)
        waypoints = new Transform[temp.Length - 1];
        //Copy the elements from the temp array to the main array we will use for waypoints. (Childs transform only)
        for(int i = 1; i < temp.Length; i++)
        {
            waypoints[i-1] = temp[i];
        }

        //Store the NavMeshAgent
        npcNavMeshAgent = GetComponent<NavMeshAgent>();
        currentNPC = GetComponent<NPCScript>();
    }

    private void Update()
    {
        if (!ui.inDialogue)
        {
            if (currentNPC.currentQuestState.Equals(QuestState.IN_PROGRESS) || currentNPC.currentQuestState.Equals(QuestState.CAN_FINISH))
            {
                npcNavMeshAgent.destination = questWait.position;
            }

            else
            {
                if (!reachedDestination)
                {
                    npcNavMeshAgent.destination = waypoints[waypointIndex].position;
                }

                if (npcNavMeshAgent.remainingDistance <= npcNavMeshAgent.stoppingDistance)
                {
                    if (!npcNavMeshAgent.pathPending)
                    {
                        reachedDestination = true;
                        waypointIndex++;

                        if (waypointIndex >= waypoints.Length)
                        {
                            waypointIndex = 0;
                        }
                    }
                }

                if (reachedDestination && npcNavMeshAgent.destination != waypoints[waypointIndex].position)
                {
                    reachedDestination = false;
                }
            }
        }
        else
        {
            gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
        }
        
    }

}
