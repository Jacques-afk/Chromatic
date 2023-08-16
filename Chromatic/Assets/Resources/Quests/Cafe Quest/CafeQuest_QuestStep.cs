using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeQuest_QuestStep : QuestStep
{
    // Quest Step

    private Spawner spawner;
    private DeliveryManManager dmManager;

    private void Awake()
    {
        //Gets the spawner script reference
        spawner = GetComponent<Spawner>();

        //Spawns the delivery man
        spawner.SpawnObject();

        //Todo, add emotion for a lost delivery man.
    }



    /// <summary>
    /// Checks to see if player has entered Collider.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entry Detected");
        //If object entered collider, and has player tag. finish the quest step.
        if (other.CompareTag("Player"))
        {
            dmManager = DeliveryManManager.instance;
            dmManager.npcFollow.canFollow = true;
            FinishQuestStep();
        }
    }
}
