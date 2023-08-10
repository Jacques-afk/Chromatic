using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAudio : MonoBehaviour
{
    private NPCScript npc;
    private TMP_Animated animatedText;

    public AudioClip[] voices;
    public AudioClip[] punctuations;

    public AudioSource voiceSource;
    public AudioSource punctuationSource;


    // Start is called before the first frame update
    void Start()
    {
        npc = GetComponent<NPCScript>();
        animatedText = InterfaceManager.instance.animatedText;
        animatedText.onTextReveal.AddListener ((newChar) => ReproduceSound(newChar));
    }

    public void ReproduceSound(char c)
    {

        if (npc != InterfaceManager.instance.currentNPC)
            return;

        if (char.IsPunctuation(c) && !punctuationSource.isPlaying)
        {
            voiceSource.Stop();
            punctuationSource.clip = punctuations[Random.Range(0, punctuations.Length)];
            punctuationSource.Play();
        }

        if (char.IsLetter(c) && !voiceSource.isPlaying)
        {
            punctuationSource.Stop();
            voiceSource.clip = voices[Random.Range(0, voices.Length)];
            voiceSource.Play();
        }

    }
}
