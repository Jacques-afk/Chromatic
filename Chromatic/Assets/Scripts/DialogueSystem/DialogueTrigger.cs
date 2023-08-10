using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using Unity.VisualScripting;

public class DialogueTrigger : MonoBehaviour
{

    private InterfaceManager ui;
    private NPCScript currentNpc;
    public CinemachineTargetGroup targetGroup;

    private GameObject player;
    private GameObject playerObj;

    private void Start()
    {
        ui = InterfaceManager.instance;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !ui.inDialogue && currentNpc != null)
        {
            Debug.Log("loaded");
            targetGroup.m_Targets[1].target = currentNpc.transform;
            ui.inDialogue = true;
            ui.CameraChange(true);
            ui.SetCharName();
            ui.ClearText();
            ui.FadeUI(true, 0.2f);
            ui.PlayPopupAnimation(0.3f);
            Debug.Log("test finished");
        }
    }

    /*public void Interact()
    {
        Debug.Log("ran");
        if (!ui.inDialogue && currentNpc != null)
        {
            Debug.Log("loaded");
            targetGroup.m_Targets[1].target = currentNpc.transform;
            ui.inDialogue = true;
            ui.CameraChange(true);
            ui.ClearText();
            ui.FadeUI(true, 0.2f, 0.65f);
            Debug.Log("test finished");
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            currentNpc = other.GetComponent<NPCScript>();
            Debug.Log(currentNpc + "In");
            ui.currentNPC = currentNpc;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        currentNpc = null;
        Debug.Log(currentNpc + "out");
        ui.currentNPC = currentNpc;
    }
}
