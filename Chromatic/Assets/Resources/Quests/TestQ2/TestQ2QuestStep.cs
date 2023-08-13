using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQ2QuestStep : QuestStep
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FinishQuestStep();
        }
    }
}
