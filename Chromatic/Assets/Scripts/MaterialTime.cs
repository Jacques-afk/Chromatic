using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTime : MonoBehaviour
{
    public Material material;

    private void Update(){
        if (material != null){
            material.SetFloat("_Time", Time.time);
        }
    }
}
