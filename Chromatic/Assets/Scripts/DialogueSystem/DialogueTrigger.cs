using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class DialogueTrigger : MonoBehaviour, IInteractable
{

    private InterfaceManager ui;
    private NPCScript currentNpc;
    public CinemachineTargetGroup targetGroup;
    private bool isInteracted = false;

    private void Start()
    {
        ui = InterfaceManager.instance;
    }

    void Update()
    {
        if(!ui.inDialogue && currentNpc != null)
        {
            targetGroup.m_Targets[1].target = currentNpc.transform;
            ui.inDialogue = true;
            ui.CameraChange(true);
            ui.ClearText();
        }
    }

    public void Interact()
    {
        isInteracted = !isInteracted;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            currentNpc = other.GetComponent<NPCScript>();
            ui.currentNPC = currentNpc;
        }
    }
}
