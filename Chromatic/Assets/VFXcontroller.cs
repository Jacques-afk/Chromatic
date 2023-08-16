using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXcontroller : MonoBehaviour
{
    public VisualEffect volcanoeVFX;
    public ParticleSystem flashbang;
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
    }

    // IEnumerator volcanoe(){
    //     yield return new WaitForSeconds(1.5f);
    //     volcanoeVFX.playRate = volcanoe_Speed;
    // }

    // public void color_Petshop(){
    //     StartCoroutine(Petshop_VFX());
    // }

    public void color_Cafe(){
        StartCoroutine(Cafe_VFX());
    }


    IEnumerator Cafe_VFX(){

        foreach (GameObject obj in cafe){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        }

        yield return new WaitForSeconds(1f);
        flashbang.Play();
        yield return new WaitForSeconds(0.8f);
        flashbang.playbackSpeed = 0.9f;
    }




    void Update(){

        if (Input.GetKeyDown(KeyCode.A)){
            color_Cafe();
        }
    }
}
