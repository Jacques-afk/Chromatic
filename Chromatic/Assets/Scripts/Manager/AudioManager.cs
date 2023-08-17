using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;

    [Header("AudioClips")]
    public AudioClip doorOpen;
    public AudioClip doorClose;
    public AudioClip dialogueButton;

    //public bool hasRun = false;
    private void Awake()
    {
        instance = this;
    }
    public void PlaySound(AudioClip audioClip)
    {
        
        audioSource.PlayOneShot(audioClip);
    }
}
