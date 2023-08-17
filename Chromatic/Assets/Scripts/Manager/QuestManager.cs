using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Dictionary<string, Quest> questMap;

    private void Awake()
    {
        questMap = CreateQuestMap();
    }

    /// <summary>
    /// Called when object is enabled. Subscribes to Game Events
    /// </summary>
    private void OnEnable()
    {
        GameEventsManager.instance.questEvents.onStartQuest += StartQuest;
        GameEventsManager.instance.questEvents.onAdvanceQuest += AdvanceQuest;
        GameEventsManager.instance.questEvents.onFinishQuest += FinishQuest;
    }

    private void Start()
    {
        //broadcast the inital stateof all quests
        foreach (Quest quest in questMap.Values)
        {
            GameEventsManager.instance.questEvents.QuestStateChange(quest);
        }
    }

    private void Update()
    {
        //Checks each quest in the questMap dictionary
        foreach (Quest quest in questMap.Values)
        {
            //if the quest meets the requirements
            if(quest.questStateInfo == QuestState.REQUIREMENTS_NOT_MET && CheckRequirementsMet(quest))
            {
                //Change the quest state to can start.
                ChangeQuestState(quest.questInfo.id, QuestState.CAN_START);
            }
        }
    }

    /// <summary>
    /// Called when updated the state of a quest. Sends out an event to keep the quest system informed of the change.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="state"></param>
    private void ChangeQuestState(string id, QuestState state)
    {
        Quest quest = GetQuestById(id);
        quest.questStateInfo = state;
        Debug.Log("Change Quest of" + id + state);
        GameEventsManager.instance.questEvents.QuestStateChange(quest);
    }

    /// <summary>
    /// Unsubscribing to Game Events
    /// </summary>
    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onStartQuest -= StartQuest;
        GameEventsManager.instance.questEvents.onAdvanceQuest -= AdvanceQuest;
        GameEventsManager.instance.questEvents.onFinishQuest -= FinishQuest;
    }

    private bool CheckRequirementsMet(Quest quest)
    {
        //Always true till proves to be false.
        bool meetsRequirements = true;

        //to check each quest prerequisites if they are completed or not.
        foreach (QuestInfoSO prerequisiteQuestInfo in quest.questInfo.questPrerequisite)
        {
            //Checks the prerequisite's quest state if its finished.
            if(GetQuestById(prerequisiteQuestInfo.id).questStateInfo != QuestState.FINISHED)
            {
                //sets the meet requirements to false.
                meetsRequirements = false;
                
            }
        }
        return meetsRequirements;
    }
    /// <summary>
    /// Starts the quest.
    /// </summary>
    /// <param name="id"></param>
    private void StartQuest(string id)
    {
        //Gets the starting quest by id
        Quest quest = GetQuestById(id);
        //Instantiates the current quest step, passes this.transform to place it at the gameobject in the scene.
        quest.InstantiateCurrentQuestStep(this.transform);
        Debug.Log(this.transform);
        //Changes its state to in progress.
        ChangeQuestState(quest.questInfo.id, QuestState.IN_PROGRESS);
    }

    private void AdvanceQuest(string id)
    {
        //Get the advancing quest by id
        Quest quest = GetQuestById(id);

        // move on to the next step
        quest.MoveToNextStep();

        //checks to see if there are more steps. if there is, instaniate the next quest step.
        if (quest.CurrentStepExists())
        {
            quest.InstantiateCurrentQuestStep(this.transform);
        }
        // checks if there are no more quest steps. if so, change the quest state to can finish.
        else
        {
            ChangeQuestState(quest.questInfo.id, QuestState.CAN_FINISH);
        }
    }

    /// <summary>
    /// Finishes the quest. Changes the quest state to finished, and calls the reward function.
    /// </summary>
    /// <param name="id"></param>
    private void FinishQuest(string id)
    {
        //Gets the quest by its id
        Quest quest = GetQuestById(id);

        //Claims the reward
        ClaimRewards();

        //Changes the quest state to finished.
        ChangeQuestState(quest.questInfo.id, QuestState.FINISHED);
    }

    /// <summary>
    /// Rewards for completing the quest.
    /// </summary>
    private void ClaimRewards()
    {
        Debug.Log("rewards!!");
    }

    private Dictionary<string, Quest> CreateQuestMap()
    {
        //To load all QuestInfoSO Scriptable Objects in Assets/Resoruces/Quest folder.
        QuestInfoSO[] allQuests = Resources.LoadAll<QuestInfoSO>("Quests");
        //Creating the Quest Map
        Dictionary<string, Quest> idToQuestMap = new Dictionary<string, Quest>();
        foreach(QuestInfoSO questInfo in allQuests)
        {
            idToQuestMap.Add(questInfo.id, new Quest(questInfo));
        }
        return idToQuestMap;
    }

    private Quest GetQuestById(string id)
    {
        Quest quest = questMap[id];
        if(quest == null)
        {
            Debug.LogError("ID Not found inside questmap." + id);
        }
        return quest;
    }
}
