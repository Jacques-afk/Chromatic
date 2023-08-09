using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="QuestInfoSO" ,menuName = "ScriptableObjects/QuestInfoSO", order = 1)]
public class QuestInfoSO : ScriptableObject
{
    [field: SerializeField] public string id { get; private set; }

    [Header("Quest Name")]
    public string displayName;

    [Header("Quest Requirements")]
    public QuestInfoSO[] questPrerequisites;

    [Header("Quest Step Prefabs")]
    public GameObject[] questStepsPrefabs;

    //Rewards to be placed here.
    //[Header("Quest Reward")]
    //Code

    private void OnValidate()
    {
        #if UNITY_EDITOR
        id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
}