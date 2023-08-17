using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public bool inDialogue;

    public static InterfaceManager instance;

    public CanvasGroup canvasGroupDialogue;
    public TMP_Animated animatedText;
    public GameObject namePlate;
    public Image nameBubble;
    public TextMeshProUGUI nameTMP;
    public GameObject dialogueArrow;
    public GameObject interactBox;
    public Animator interactBoxAnimator;
    public TextMeshProUGUI interactBoxText;
    public Animator blackBoxAnimator;
    public GameObject pauseMenu;

    [HideInInspector]
    public NPCScript currentNPC;
    private bool npcHasQuest;

    private int dialogueIndex;
    public bool canExit;
    public bool nextDialogue;
    public bool currentDialogueEnded = true;

    [Header("Cameras")]
    public GameObject gameCamera;
    public GameObject dialogueCamera;

    private DialogueData dialogue;
    private bool isDialogueMonologue = false;

    private AudioManager audioManager;


    [Header("Quest Log Variables")]
    public TextMeshProUGUI questName;
    public TextMeshProUGUI questDescription;
    public TextMeshProUGUI questGiver;
    public Button questButtonPrefab;
    public Transform questButtonParentTransform;
    public List<Quest> questList;

    //Testing
    public UnityEventsTest eventsTest;

    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioManager = AudioManager.instance;
        animatedText.onDialogueEnd.AddListener(() => EndDialogue());
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.O))
        {
            CreateQuestButton();
        }
        if (Input.GetKeyDown(KeyCode.E) && inDialogue)
        {
            interactBox.SetActive(false);

            if (canExit)
            {
                //Switches back the camera
                CameraChange(false);
                //
                StartCoroutine(FadeUIRoutine(false, 0.2f));
                StartCoroutine(ResetStateAfterDelay(0.8f));
                Debug.Log("Dialogue Exited.");
                audioManager.PlaySound(audioManager.dialogueButton);

                if (npcHasQuest == true)
                {
                    StartorEndQuest();
                }
                

                interactBox.SetActive(true);
                if (!isDialogueMonologue)
                {
                    currentNPC.npcAnimator.SetTrigger("normal");

                    if (currentNPC.hasTalked == false)
                    {
                        currentNPC.hasTalked = true;
                    }

                    currentNPC.outlineMaterialManager.AddMaterialToAll();
                }

                isDialogueMonologue = false;
                npcHasQuest = false;
            }

            else if (nextDialogue)
            {
                //TODO - Make sure that text has ended first.
                if (currentDialogueEnded)
                {
                    audioManager.PlaySound(audioManager.dialogueButton);
                    dialogueArrow.SetActive(false);
                    animatedText.ReadText(dialogue.dialogueText[dialogueIndex]);
                    currentDialogueEnded = false;
                    Debug.Log("Next Dialogue initiated");

                }


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

            CreateQuestButton();

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
            if (!isDialogueMonologue)
            {
                namePlate.SetActive(true);
            }
            animatedText.ReadText(dialogue.dialogueText[0]);

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
        dialogueArrow.SetActive(true);
        if (dialogueIndex < dialogue.dialogueText.Count -1)
        {
            dialogueIndex++;
            nextDialogue = true;
            currentDialogueEnded = true;

        }
        else
        {
            nextDialogue = false;
            canExit = true;
        }

        
       

    }

    public void TurnToPlayer(Transform targetTransform)
    {
        Vector3 directionToTarget = targetTransform.position - currentNPC.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        currentNPC.transform.rotation = targetRotation;
    }

    public void HideNamePlate()
    {
        namePlate.SetActive(false);
    }

    public void GetDialogueDataPlayer(DialogueData x)
    {
        dialogue = x;
        isDialogueMonologue = true;
    }

    public void GetDialogueDataNPC()
    {
        if (currentNPC.currentQuestState.Equals(QuestState.CAN_START))
        {
            dialogue = currentNPC.data.dialogueQuestStart;
        }
        else if (currentNPC.currentQuestState.Equals(QuestState.IN_PROGRESS))
        {
            dialogue = currentNPC.data.dialogueQuestInProgress;
        }
        else if (currentNPC.currentQuestState.Equals(QuestState.CAN_FINISH))
        {
            dialogue = currentNPC.data.dialogueQuestEnded;
        }
        else if (currentNPC.hasTalked == true)
        {
            dialogue = currentNPC.data.dialogueData2;
        }
        else
        {
            dialogue = currentNPC.data.dialogueData;
        }

        npcHasQuest = currentNPC.hasQuest;
    }

    public void FadeBlack()
    {
        blackBoxAnimator.SetBool("canFadeIn", true);
        StartCoroutine(FadeOut());
        
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1.5f);
        blackBoxAnimator.SetBool("canFadeIn", false);
        blackBoxAnimator.SetBool("canFadeOut", true);
        yield return new WaitForSeconds(0.1f);
        blackBoxAnimator.SetBool("canFadeOut", false);

    }

    public void OpenPauseMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void ClosePauseMenu()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void CreateQuestButton()
    {
        Button newQuestButton = Instantiate(questButtonPrefab, questButtonParentTransform);
        QuestLogButton questLogButton = newQuestButton.GetComponent<QuestLogButton>();
        questLogButton.npc = currentNPC;
        questLogButton.InitializeButton();

        
    }
   public void ClearQuestLogButton()
    {
        questDescription.text = "";
        questName.text = "";
        questGiver.text = "";
    }
}
