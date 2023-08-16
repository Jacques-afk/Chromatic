using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeQuestQuestStep2 : QuestStep
{
    private DeliveryManManager dmManger;

    private void Awake()
    {
        dmManger = DeliveryManManager.instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            dmManger.npcFollow.canFollow = false;
            FinishQuestStep();
        }
    }


}
