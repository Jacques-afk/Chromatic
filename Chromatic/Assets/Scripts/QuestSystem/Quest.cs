using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{

    //Quest's Static Info
    public QuestInfoSO questInfo;

    //Quest's current State
    public QuestState questStateInfo;
    private int currentQuestStepIndex;

    public Quest(QuestInfoSO questInfo)
    {
        this.questInfo = questInfo;
        this.questStateInfo = QuestState.REQUIREMENTS_NOT_MET;
        this.currentQuestStepIndex = 0;
    }

    public void MoveToNextStep()
    {
        currentQuestStepIndex++;
    }

    public bool CurrentStepExists()
    {
        return (currentQuestStepIndex < questInfo.questStepsPrefabs.Length);
    }

    public void InstantiateCurrentQuestStep(Transform parentTransform)
    {
        GameObject questStepPrefab = GetCurrentQuestStepPrefab();
        if(questStepPrefab != null)
        {
            QuestStep questStep = Object.Instantiate<GameObject>(questStepPrefab, parentTransform)
                .GetComponent<QuestStep>();
            questStep.InitializeQuestStep(questInfo.id);
        }
    }

    private GameObject GetCurrentQuestStepPrefab()
    {
        GameObject questStepPrefab = null;
        if (CurrentStepExists())
        {
            questStepPrefab = questInfo.questStepsPrefabs[currentQuestStepIndex];
        }

        return questStepPrefab;
    }
}

