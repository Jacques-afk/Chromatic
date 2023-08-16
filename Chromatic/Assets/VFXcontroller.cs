using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXcontroller : MonoBehaviour
{
    public VisualEffect volcanoeVFX;
    public float volcanoe_Speed = 0.02f;

    public GameObject[] petshop;
    public GameObject[] cafe;

    void Awake(){
        // petshop = GameObject.FindGameObjectsWithTag("petshop");
        cafe = GameObject.FindGameObjectsWithTag("cafe");
    }


    void Start()
    {
        // StartCoroutine(volcanoe());
        StartCoroutine(demonstrate());
    }


    IEnumerator demonstrate(){
        yield return new WaitForSeconds(5f);
        // color_Petshop();
        color_Cafe();
    }

    // IEnumerator volcanoe(){
    //     yield return new WaitForSeconds(1.5f);
    //     volcanoeVFX.playRate = volcanoe_Speed;
    // }

    public void color_Petshop(){
        foreach (GameObject obj in petshop){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        }
    }

    public void color_Cafe(){
        foreach (GameObject obj in cafe){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        }
    }
    

}
