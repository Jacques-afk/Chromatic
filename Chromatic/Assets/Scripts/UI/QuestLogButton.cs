using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuestLogButton : MonoBehaviour
{
    public NPCScript npc;
    public TextMeshProUGUI ButtonName;
    public string questGiver;
    public string questTitle;
    public string questDescription;
    private InterfaceManager ui;

    private void Awake()
    {
        //ButtonName.text = npc.data.npcQuest.displayName.ToString();
    }

    private void Start()
    {
        ui = InterfaceManager.instance;
    }

    public void InitializeButton()
    {
        ButtonName.text = npc.data.npcQuest.displayName.ToString();
        questGiver = npc.data.npcQuest.questGiver.ToString();
        questTitle = npc.data.npcQuest.displayName.ToString();
        questDescription = npc.data.npcQuest.questDescription.ToString();
    }

    public void OnClick()
    {
        //Load data to Quest Description.
        ui.questDescription.text = questDescription;
        ui.questName.text = questTitle;
        ui.questGiver.text = questGiver;
    }
}
