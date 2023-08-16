using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeQuestQuestStep2 : QuestStep
{
    private NPCQuestManager npcManager;

    private void Awake()
    {
        npcManager = NPCQuestManager.instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            npcManager.npcFollow.canFollow = false;
            npcManager.DestroyNPC();
            FinishQuestStep();
        }
    }


}
