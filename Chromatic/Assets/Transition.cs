using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Transition : MonoBehaviour
{
    public VisualEffect fireworks;
    public ParticleSystem confetti;

    void Start(){
        fireworks.Stop();
        confetti.Stop();
    }

    public void endDecrease(){
        confetti.Play();
        StartCoroutine(fireworksStop());
    }
    

    IEnumerator fireworksStop(){
        fireworks.Play();
        yield return new WaitForSeconds(2f);
        fireworks.Stop();
    }

}
