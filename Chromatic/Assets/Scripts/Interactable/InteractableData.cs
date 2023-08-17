using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "InteractableData", menuName = "New Interactable")]
public class InteractableData : ScriptableObject
{
    public DialogueData dialogue;
}
