using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using Unity.VisualScripting;

public class DialogueTrigger : MonoBehaviour
{
    /// <summary>
    /// Reference to the Interface Manager, which manages the dialogue system
    /// </summary>
    private InterfaceManager ui;

    /// <summary>
    /// Reference to the NPC thats being interacted with
    /// </summary>
    private NPCScript currentNpc;

    /// <summary>
    /// Reference to the Cinemachine TargetGroup
    /// </summary>
    public CinemachineTargetGroup targetGroup;

    /// <summary>
    /// Called when the game starts, stores reference to the interface manager's instance
    /// </summary>
    private void Start()
    {
        //Get the instance of the Interface manager
        ui = InterfaceManager.instance;

    }

    /// <summary>
    /// When objects overlap.
    /// Stores the NPC information and passes it to the interface manager as long is its in the trigger volume.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            currentNpc = other.GetComponent<NPCScript>();
            ui.currentNPC = currentNpc;
        }
    }

    /// <summary>
    /// When objects exit the trigger volume
    /// Sets the npc to null in the interface manager when the npc exits the trigger.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        currentNpc = null;
        ui.currentNPC = currentNpc;
    }

    /// <summary>
    /// Called when Interact action is pressed
    /// Checks if npc is not null and player is not in dialogue. Then load the dialogue information and start the dialogue.
    /// </summary>
    void OnInteract()
    {
        if (!ui.inDialogue && currentNpc != null)
        {
            targetGroup.m_Targets[1].target = currentNpc.transform;
            ui.inDialogue = true;
            ui.CameraChange(true);
            ui.SetCharName();
            ui.ClearText();
            ui.FadeUI(true, 0.2f);
            ui.PlayPopupAnimation(0.3f);
            ui.currentDialogueEnded = false;
        }
    }
}
