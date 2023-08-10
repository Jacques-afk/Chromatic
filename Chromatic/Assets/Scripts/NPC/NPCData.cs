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

}
