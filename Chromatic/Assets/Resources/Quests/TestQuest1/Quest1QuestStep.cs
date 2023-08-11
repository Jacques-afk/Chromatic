using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1QuestStep : QuestStep
{

    /// <summary>
    /// Checks to see if player has entered Collider.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //If object entered collider, and has player tag. finish the quest step.
        if (other.CompareTag("Player"))
        {
            FinishQuestStep();
        }
    }

}
