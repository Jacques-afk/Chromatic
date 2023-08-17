using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXcontroller : MonoBehaviour
{
    public VisualEffect volcanoeVFX;
    public ParticleSystem flashbang;
    public GameObject sea;
    public GameObject pond;

    public float volcanoe_Speed = 0.02f;

    public GameObject[] petshop;
    public GameObject[] cafe;
    public GameObject[] MChome;

    public GameObject[] parkArea2;

    public Material grass_TA1;
    public Material grass_TA2;
    public Material grass_TA3;
    public Material grass_TA4;
    
    void Awake(){
        // petshop = GameObject.FindGameObjectsWithTag("petshop");
        cafe = GameObject.FindGameObjectsWithTag("cafe");
        parkArea2 = GameObject.FindGameObjectsWithTag("parkArea2");
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

    public void color_Sea(){

    }

    public void color_mcHouse(){

    }

    public void color_parkArea2(){
        StartCoroutine(parkArea2_VFX());
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



    IEnumerator parkArea2_VFX(){
        yield return new WaitForSeconds(0.001f);

        // foreach (GameObject obj in parkArea2){
        //     changy colorswap = obj.GetComponent<changy>();
        //     colorswap.enabled = true;
        // }

        yield return new WaitForSeconds(1f);
        // grass_TA2.
        
        grass_TA2.SetColor("_GrassColor", Color.white);

        // flashbang.Play();
        // yield return new WaitForSeconds(0.8f);
        // flashbang.playbackSpeed = 0.9f;
    }



    void Update(){

        if (Input.GetKeyDown(KeyCode.A)){

            color_parkArea2();
            // color_Cafe();
        }
    }
}
