using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "NPCData", menuName = "New NPC")]
public class NPCData : ScriptableObject
{

    public string npcName;
    public DialogueData dialogueData;
    public DialogueData dialogueData2;
    public QuestInfoSO npcQuest;

    public bool startPoint = true;
    public bool endPoint = true;

    public DialogueData dialogueQuestStart;
    public DialogueData dialogueQuestInProgress;
    public DialogueData dialogueQuestEnded;
    

}
