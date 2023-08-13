using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAudio : MonoBehaviour
{
    /// <summary>
    /// Reference to the npc
    /// </summary>
    private NPCScript npc;

    /// <summary>
    /// Reference to the animated text in the dialogue.
    /// </summary>
    private TMP_Animated animatedText;

    /// <summary>
    /// an array to store character voice sounds
    /// </summary>
    public AudioClip[] voices;

    /// <summary>
    /// an array to store character punctuation sounds
    /// </summary>
    public AudioClip[] punctuations;

    /// <summary>
    /// Source of the the voice, which the voices should be played at.
    /// </summary>
    public AudioSource voiceSource;

    /// <summary>
    /// Source of the punctuation sounds.
    /// </summary>
    public AudioSource punctuationSource;


    /// <summary>
    /// Start is called before the first frame update
    /// Stores the npc reference
    /// stores the active animated text reference from the interface
    /// Subscribes to onTextReval, and calls the reproduce sound function
    /// </summary>
    void Start()
    {
        npc = GetComponent<NPCScript>();
        animatedText = InterfaceManager.instance.animatedText;
        animatedText.onTextReveal.AddListener ((newChar) => ReproduceSound(newChar));
    }

    /// <summary>
    /// Play a random voice or punctuation
    /// </summary>
    /// <param name="c"></param>
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
