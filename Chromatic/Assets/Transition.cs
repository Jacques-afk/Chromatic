using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Transition : MonoBehaviour
{
    public VisualEffect fireworks;

    void Start(){
        fireworks.Stop();
    }

    public void endDecrease(){
        StartCoroutine(fireworksStop());
    }
    
    IEnumerator fireworksStop(){
        fireworks.Play();
        yield return new WaitForSeconds(2f);
        fireworks.Stop();
    }

}
