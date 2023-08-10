using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class NPCScript : MonoBehaviour
{
    public NPCData data;
    public DialogueData dialogue;

    public bool isNPCTalking;

    private TMP_Animated animatedText;
    //private DialogueAudio
    //private animator

    //public Tranform particlesParent;

    void Start()
    {
        animatedText = InterfaceManager.instance.animatedText;
        //animatedText.onEmotionChange.AddListener((newEmotion) => EmotionChanger(newEmotion));
        animatedText.onAction.AddListener((action) => SetAction(action));
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
}
