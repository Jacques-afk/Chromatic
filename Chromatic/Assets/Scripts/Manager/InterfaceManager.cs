using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public bool inDialogue;

    public static InterfaceManager instance;

    public CanvasGroup canvasGroup;
    public TMP_Animated animatedText;
    public TextMeshProUGUI nameTMP;

    public NPCScript currentNPC;

    private int dialogueIndex;
    public bool canExit;
    public bool nextDialogue;

    public GameObject gameCamera;
    public GameObject dialogueCamera;

    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //listens to event for when dialogue ends.
        animatedText.onDialogueEnd.AddListener(() => EndDialogue());
    }

    private void Update()
    {
        if (inDialogue)
        {
            if (canExit)
            {

            }
            if (nextDialogue)
            {

            }
        }
    }

    //TODO - ADD FUNCTION TO MAKE UI DISAPPEAR. (FADE?)

    public void CameraChange(bool dialogue)
    {
        gameCamera.SetActive(!dialogue);
        dialogueCamera.SetActive(dialogue);
    }
    public void ClearText()
    {
        animatedText.text = string.Empty;
    }

    public void ResetState()
    {
        //currentNPC.Reset();
        inDialogue = false;
        canExit = false;
    }


    public void EndDialogue()
    {
        if (dialogueIndex < currentNPC.dialogue.dialogueText.Count - 1)
        {
            dialogueIndex++;
            nextDialogue = true;
        }
        else
        {
            nextDialogue = false;
            canExit = true;
        }
    }
}
