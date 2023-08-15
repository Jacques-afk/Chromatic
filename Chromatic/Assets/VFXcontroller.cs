using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXcontroller : MonoBehaviour
{
    public VisualEffect volcanoeVFX;
    public float volcanoe_Speed = 0.02f;

    void Start()
    {
        StartCoroutine(volcanoe());
    }

    IEnumerator volcanoe(){
        yield return new WaitForSeconds(1.5f);
        volcanoeVFX.playRate = volcanoe_Speed;
    }
    
}
