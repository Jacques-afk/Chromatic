using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryPigeons_QuestStep_1 : QuestStep
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FinishQuestStep();
        }
    }
}
