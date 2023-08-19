using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostSonQuestStep1 : QuestStep
{
    private Spawner spawner;

    //public Actio stopFollow;

    private void Awake()
    {
        spawner = GetComponent<Spawner>();
        spawner.SpawnObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FinishQuestStep();
        }
    }
}
