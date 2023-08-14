using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using UnityEngine.AI;

public class NPCScript : MonoBehaviour
{
    /// <summary>
    /// NPC Data, Name, Quest
    /// </summary>
    public NPCData data;
    
    /// <summary>
    /// Current active Quest State
    /// </summary>
    [HideInInspector]
    public QuestState currentQuestState;

    /// <summary>
    /// String ID of Quest
    /// </summary>
    [HideInInspector]
    public string questID;

    /// <summary>
    /// Boolean if NPC has a quest
    /// </summary>
    [HideInInspector]
    public bool hasQuest;

    /// <summary>
    /// Boolean for if NPC is talking.
    /// </summary>
    public bool isNPCTalking;

    private TMP_Animated animatedText;

    public bool isHappy;

    //private DialogueAudio
    //private animator

    //public Tranform particlesParent;

    //Animation Variables
    [HideInInspector]
    public Animator npcAnimator;

    private bool isWalking = false;

    private NavMeshAgent navMeshAgent;

    private Vector3 npcVelocity;
    private float npcMovementThreshold = 0.1f;


    private void Awake()
    {

        //Check if NPC has quest
        if (data.npcQuest.id != "EmptyScript")
        {
            //Gets the quest id from quest.
            questID = data.npcQuest.id;

            //Sets has Quest to true.
            hasQuest = true;

        }
        else
        {
            hasQuest = false;
        }


    }

    private void OnEnable()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange += QuestStateChange;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange -= QuestStateChange;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="quest"></param>
    private void QuestStateChange(Quest quest)
    {
        Debug.Log(quest + "run!");
        //Checks to see if the Quest ID matches the current quest, get the current quest state.
        if (quest.questInfo.id.Equals(questID))
        {
            Debug.Log(quest);
            currentQuestState = quest.questStateInfo;
        }

    }

    void Start()
    {
        npcAnimator = GetComponent<Animator>();
        animatedText = InterfaceManager.instance.animatedText;
        //animatedText.onEmotionChange.AddListener((newEmotion) => EmotionChanger(newEmotion));
        animatedText.onAction.AddListener((action) => SetAction(action));
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    /*public void EmotionChanger(Emotion e)
    {
        if (this != InterfaceManager.instance.currentVillager)
            return;

        animator.SetTrigger(e.ToString());

        if (e == Emotion.suprised)
            eyesRenderer.material.SetTextureOffset("_BaseMap", new Vector2(.33f, 0));

        if (e == Emotion.angry)
            eyesRenderer.material.SetTextureOffset("_BaseMap", new Vector2(.66f, 0));

        if (e == Emotion.sad)
            eyesRenderer.material.SetTextureOffset("_BaseMap", new Vector2(.33f, -.33f));
    }*/

    private void Update()
    {
        CheckWalk();
        HandleAnimation();
        Debug.Log(isWalking);
    }

    private void HandleAnimation()
    {
        if (isHappy)
        {
            npcAnimator.SetBool("isHappy",true);
        }
        else
        {
            npcAnimator.SetBool("isHappy", false);
        }

        if (isWalking)
        {
            npcAnimator.SetBool("isWalking",true);

        }
        else
        {
            npcAnimator.SetBool("isWalking", false);
        }
    }
    public void SetAction(string action)
    {
        if (this != InterfaceManager.instance.currentNPC)
        {
            return;
        }

        if (action == "shake")
        {
            Camera.main.GetComponent<CinemachineImpulseSource>().GenerateImpulse();
        }
        else
        {
            Debug.Log("hi");
        }

        /*else
        {
            PlayParticle(action);

            if (action == "sparkle")
            {
                dialogueAudio.effectSource.clip = dialogueAudio.sparkleClip;
                dialogueAudio.effectSource.Play();
            }
            else if (action == "rain")
            {
                dialogueAudio.effectSource.clip = dialogueAudio.rainClip;
                dialogueAudio.effectSource.Play();
            }
        } */
    }

    private void CheckWalk()
    {
        if(navMeshAgent != null)
        {
            float speed;
            npcVelocity = navMeshAgent.velocity;
            speed = npcVelocity.magnitude;
            if (speed > npcMovementThreshold)
            {
                isWalking = true;
            }
            else
            {
                isWalking = false;
            }
        }
        
    }
}
