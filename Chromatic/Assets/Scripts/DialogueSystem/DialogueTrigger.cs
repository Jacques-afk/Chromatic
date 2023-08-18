using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private InterfaceManager ui;
    public DialogueData dialogue;
    private PlayerMovement playerMovement;


    // Start is called before the first frame update
    void Start()
    {
        ui = InterfaceManager.instance;
        playerMovement = FindAnyObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ui.GetDialogueDataPlayer(dialogue);
            
            ui.inDialogue = true;
            // Remove Name Plate
            if (dialogue.playerMonologue)
            {
                ui.HideNamePlate();
            }
            ui.ClearText();
            ui.FadeUI(true, 0.2f);
            ui.PlayPopupAnimation(0.3f);
            ui.dialogueArrow.SetActive(false);
            ui.currentDialogueEnded = false;
            playerMovement.isSprint = false;
            playerMovement.isWalk = false;
            playerMovement.animator.SetTrigger("Normal");
            Destroy(this.gameObject);
        }
    }
}
