using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "DialogueData", menuName = "New Dialogue")]
public class DialogueData : ScriptableObject
{

    /// <summary>
    /// Stores the dialogue
    /// </summary>
    [TextArea(4, 4)]
    public List<string> dialogueText;
}
