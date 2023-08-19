using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXcontroller : MonoBehaviour
{

    public static VFXcontroller instance;

    public VisualEffect volcanoeVFX;
    public ParticleSystem flashbang;
    public GameObject sea;
    public GameObject pond;

    public float volcanoe_Speed = 0.02f;

    public GameObject[] petshop;
    public GameObject[] cafe;
    public GameObject[] MChome;
    public GameObject[] terrain;

    public GameObject[] townArea1;
    public GameObject[] townArea2;
    public GameObject[] townArea3;
    public GameObject[] townArea4;

    public GameObject[] parkArea1;
    public GameObject[] parkArea2;
    public GameObject[] parkArea3;
    public GameObject[] parkArea4;

    public GameObject[] sideArea1;
    public GameObject[] sideArea2;
    public GameObject[] sideArea3;

    public GameObject[] beach;

    public Material grass_TA1;
    public Material grass_TA2;
    public Material grass_TA3;
    public Material grass_TA4;
    
    void Awake(){

        instance = this;

        petshop = GameObject.FindGameObjectsWithTag("petshop");
        cafe = GameObject.FindGameObjectsWithTag("cafe");
        MChome = GameObject.FindGameObjectsWithTag("MChouse");
        terrain = GameObject.FindGameObjectsWithTag("terrain");

        townArea1 = GameObject.FindGameObjectsWithTag("townArea1");
        townArea2 = GameObject.FindGameObjectsWithTag("townArea2");
        townArea3 = GameObject.FindGameObjectsWithTag("townArea3");
        townArea4 = GameObject.FindGameObjectsWithTag("townArea4");

        parkArea1 = GameObject.FindGameObjectsWithTag("parkArea1");
        parkArea2 = GameObject.FindGameObjectsWithTag("parkArea2");
        parkArea3 = GameObject.FindGameObjectsWithTag("parkArea3");
        parkArea4 = GameObject.FindGameObjectsWithTag("parkArea4");

        sideArea1 = GameObject.FindGameObjectsWithTag("sideArea1");
        sideArea2 = GameObject.FindGameObjectsWithTag("sideArea2");
        sideArea3 = GameObject.FindGameObjectsWithTag("sideArea3");

        beach = GameObject.FindGameObjectsWithTag("beach");
    }

    // void Start()
    // {
    //     StartCoroutine(volcanoe());
    // }

    // IEnumerator volcanoe(){
    //     yield return new WaitForSeconds(1.5f);
    //     volcanoeVFX.playRate = volcanoe_Speed;
    // }


    
    public void color_Petshop(){         //interior
        StartCoroutine(Petshop_VFX());
    }

    public void color_Cafe(){          //interior
        StartCoroutine(Cafe_VFX());
    }

    public void color_mcHouse(){           //exterior
        StartCoroutine(MChouse_VFX());
    }

    public void color_terrain(){
        StartCoroutine(terrain_VFX());
    }




    public void color_parkArea1(){
        StartCoroutine(parkArea1_VFX());
    }

    public void color_parkArea2(){
        StartCoroutine(parkArea2_VFX());
    }

    public void color_parkArea3(){
        StartCoroutine(parkArea3_VFX());
    }

    public void color_parkArea4(){
        StartCoroutine(parkArea4_VFX());
    }

    public void color_townArea1(){
        StartCoroutine(townArea1_VFX());
    }

    public void color_townArea2(){
        StartCoroutine(townArea2_VFX());
    }
    
    public void color_townArea3(){
        StartCoroutine(townArea3_VFX());
    }

    public void color_townArea4(){
        StartCoroutine(townArea4_VFX());
    }

    public void color_sideArea1(){
        StartCoroutine(sideArea1_VFX());
    }

    public void color_sideArea2(){
        StartCoroutine(sideArea2_VFX());
    }

    public void color_sideArea3(){
        StartCoroutine(sideArea3_VFX());
    }

    public void color_beach(){
        StartCoroutine(beach_VFX());
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

    IEnumerator Petshop_VFX(){

        foreach (GameObject obj in petshop){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        }

        yield return new WaitForSeconds(1f);
        flashbang.Play();
        yield return new WaitForSeconds(0.8f);
        flashbang.playbackSpeed = 0.9f;
    }

    IEnumerator terrain_VFX(){

        foreach (GameObject obj in terrain){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return null;
    }

    IEnumerator MChouse_VFX(){

        foreach (GameObject obj in MChome){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return null;
    }


    IEnumerator townArea1_VFX(){

        foreach (GameObject obj in townArea1){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return null;
    }

    IEnumerator townArea2_VFX(){

        foreach (GameObject obj in townArea2){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return null;
    }

    IEnumerator townArea3_VFX(){

        foreach (GameObject obj in townArea3){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return null;
    }

    IEnumerator townArea4_VFX(){

        foreach (GameObject obj in townArea4){
            Debug.Log(obj.name);
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return null;
    }

    IEnumerator parkArea1_VFX(){

        foreach (GameObject obj in parkArea1){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return null;
    }

    IEnumerator parkArea2_VFX(){

        foreach (GameObject obj in parkArea2){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return null;
    }

    IEnumerator parkArea3_VFX(){

        foreach (GameObject obj in parkArea3){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return null;
    }

    IEnumerator parkArea4_VFX(){

        foreach (GameObject obj in parkArea4){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return null;
    }

    IEnumerator sideArea1_VFX(){

        foreach (GameObject obj in sideArea1){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return null;
    }

    IEnumerator sideArea2_VFX(){

        foreach (GameObject obj in sideArea2){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return null;
    }

    IEnumerator sideArea3_VFX(){

        foreach (GameObject obj in sideArea3){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return null;
    }

    IEnumerator beach_VFX(){

        foreach (GameObject obj in beach){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return null;
    }




    void Update(){

        if (Input.GetKeyDown(KeyCode.F)){
            color_townArea4();  
        }
    }
}
 