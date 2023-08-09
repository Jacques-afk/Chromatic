using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class QuestStep : MonoBehaviour
{
    /// <summary>
    /// Boolean to check if the quest step is finished
    /// </summary>
    private bool isFinished = false;

    /// <summary>
    /// String to store the current quest id.
    /// </summary>
    private string questId;
    
    /// <summary>
    /// Sets the quest id when Initialized.
    /// </summary>
    /// <param name="questId"></param>
    public void InitializeQuestStep(string questId)
    {
        this.questId = questId;
    }
    
    /// <summary>
    /// Called when the quest step is finished. To be called in the extensions.
    /// </summary>
    protected void FinishQuestStep()
    {
        //Checks if the quest step if finished.
        if (!isFinished)
        {
            //Sets it to true
            isFinished = true;

            //Calls an event to Advance the Quest
            GameEventsManager.instance.questEvents.AdvanceQuest(questId);

            //Destroys itself so that
            Destroy(this.gameObject);
        }
    }

}
