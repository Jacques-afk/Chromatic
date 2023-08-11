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
        //Subcribes to onQuestStateChange.
        GameEventsManager.instance.questEvents.onQuestStateChange += QuestStateChange;
        //GameEventsManager.instance.inputEvents // Subscribes to the OnSubmitPressed event.
    }

    //Change to When Dialogue as ended.
    private void OnSubmitPressed()
    {
        if (!playerIsNear)
        {
            return;
        }

        //Starts the quest through the GameEventsManager
        if(currentQuestState.Equals(QuestState.CAN_START) && startPoint)
        {
            GameEventsManager.instance.questEvents.StartQuest(questID);
        }
        //Ends the quest.
        else if(currentQuestState.Equals(QuestState.CAN_FINISH) && endPoint)
        {
            GameEventsManager.instance.questEvents.FinishQuest(questID);
        }
    }

    /// <summary>
    /// Unsubscribes to the event on quest state change, once quest is completed.
    /// </summary>
    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange -= QuestStateChange;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="quest"></param>
    private void QuestStateChange(Quest quest)
    {
        //Checks to see if the Quest ID matches the current quest, get the current quest state.
        if (quest.questInfo.id.Equals(questID))
        {
            currentQuestState = quest.questStateInfo;
        }
    }

    //Can remove.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
        }
    }
}
