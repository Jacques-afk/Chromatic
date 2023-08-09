using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Collider))]
public class QuestPoint : MonoBehaviour
{
    [Header("Quest")]
    [SerializeField] private QuestInfoSO questInfoForPoint;
    private bool playerIsNear = false;
    private string questID;
    private QuestState currentQuestState;

    /// <summary>
    /// Determines whether the this is the start or end point of the quest.
    /// </summary>
    [Header("Config")]
    [SerializeField] private bool startPoint;
    [SerializeField] private bool endPoint;

    private void Awake()
    {
        questID = questInfoForPoint.id;
    }

    private void OnEnable()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange += QuestStateChange;
        //GameEventsManager.instance.inputEvents // Subscribes to the OnSubmitPressed event.
    }

    private void OnSubmitPressed()
    {
        if (!playerIsNear)
        {
            return;
        }

        //start or finish the quest.
        if(currentQuestState.Equals(QuestState.CAN_START) && startPoint)
        {
            GameEventsManager.instance.questEvents.StartQuest(questID);
        }
        else if(currentQuestState.Equals(QuestState.CAN_FINISH) && endPoint)
        {
            GameEventsManager.instance.questEvents.FinishQuest(questID);
        }
    }

    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange -= QuestStateChange;
    }

    private void QuestStateChange(Quest quest)
    {
        if (quest.questInfo.id.Equals(questID))
        {
            currentQuestState = quest.questStateInfo;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
