using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public bool inDialogue;

    public static InterfaceManager instance;

    public CanvasGroup canvasGroupDialogue;
    public TMP_Animated animatedText;
    public Image nameBubble;
    public TextMeshProUGUI nameTMP;

    [HideInInspector]
    public NPCScript currentNPC;

    private int dialogueIndex;
    public bool canExit;
    public bool nextDialogue;

    [Header("Cameras")]
    public GameObject gameCamera;
    public GameObject dialogueCamera;


    //Testing
    public UnityEventsTest eventsTest;

    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        animatedText.onDialogueEnd.AddListener(() => EndDialogue());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inDialogue)
        {
            if (canExit)
            {
                if (currentNPC.hasQuest == true)
                {
                    StartorEndQuest();
                }
                CameraChange(false);
                StartCoroutine(FadeUIRoutine(false, 0.2f));
                StartCoroutine(ResetStateAfterDelay(0.8f));
                Debug.Log("Dialogue Exited.");

                //Call quest point here.
                
            }

            else if (nextDialogue)
            {
                animatedText.ReadText(currentNPC.data.dialogueData.dialogueText[dialogueIndex]);
            }
        }
    }

    /// <summary>
    /// Starts or ends the quest if theres a present quest avaialble.
    /// </summary>
    private void StartorEndQuest()
    {
        Debug.Log("Quest Started.");
        Debug.Log(currentNPC.currentQuestState);
        if (currentNPC.currentQuestState.Equals(QuestState.CAN_START) && currentNPC.data.startPoint)
        {
            GameEventsManager.instance.questEvents.StartQuest(currentNPC.questID);
            Debug.Log(currentNPC.data.npcQuest.displayName + "Has started");
        }
        else if (currentNPC.currentQuestState.Equals(QuestState.CAN_FINISH) && currentNPC.data.endPoint)
        {
            GameEventsManager.instance.questEvents.FinishQuest(currentNPC.questID);
        }
    }

    private IEnumerator ResetStateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ResetState();
    }

    public void PlayPopupAnimation(float time)
    {
        StartCoroutine(PopupAnimationRoutine(time));
    }

    private IEnumerator PopupAnimationRoutine(float time)
    {
        float startScale = 0;
        float targetScale = 1;
        float scaleElapsedTime = 0;

        while (scaleElapsedTime < time)
        {
            scaleElapsedTime += Time.deltaTime;
            float newScale = Mathf.SmoothStep(startScale, targetScale, scaleElapsedTime / time);
            canvasGroupDialogue.transform.localScale = new Vector3(newScale, newScale, 1);
            yield return null;
        }

        canvasGroupDialogue.transform.localScale = Vector3.one;
    }

    public void FadeUI(bool show, float time)
    {
        StartCoroutine(FadeUIRoutine(show, time));
        if (show)
        {
            dialogueIndex = 0;
        }
    }

    private IEnumerator FadeUIRoutine(bool show, float time)
    {
        float startAlpha = canvasGroupDialogue.alpha;
        float targetAlpha = show ? 1 : 0;
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / time);
            canvasGroupDialogue.alpha = newAlpha;
            yield return null;
        }

        canvasGroupDialogue.alpha = targetAlpha;

        if (show)
        {
            animatedText.ReadText(currentNPC.data.dialogueData.dialogueText[0]);
        }
    }


    public void SetCharName()
    {
        nameTMP.text = currentNPC.data.npcName;

    }

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
        inDialogue = false;
        canExit = false;
    }

    public void EndDialogue()
    {
        if (dialogueIndex < currentNPC.data.dialogueData.dialogueText.Count - 1)
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
