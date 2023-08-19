using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXcontroller : MonoBehaviour
{

    public static VFXcontroller instance;

    public VisualEffect volcanoeVFX;
    public float volcanoe_Speed = 0.02f;

    public GameObject ocean;
    public GameObject fakeOcean;

    public GameObject pond;
    public GameObject fakePond;
 
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

    public Material grass_PA1;
    public Material grass_PA2;
    public Material grass_PA3;
    public Material grass_PA4;

    public Material grass_SA1;
    public Material grass_SA2;
    public Material grass_SA3;

    public Material treeLeaves_TA1;
    public Material treeBark_TA1;
    public Material treeLeaves_TA2;
    public Material treeBark_TA2;
    public Material treeLeaves_TA3;
    public Material treeBark_TA3;
    public Material treeLeaves_TA4;
    public Material treeBark_TA4;

    public Material treeLeaves_PA1;
    public Material treeBark_PA1;
    public Material treeLeaves_PA2;
    public Material treeBark_PA2;
    public Material treeLeaves_PA3;
    public Material treeBark_PA3;
    public Material treeLeaves_PA4;
    public Material treeBark_PA4;

    public Material treeLeaves_SA1;
    public Material treeBark_SA1;
    public Material treeLeaves_SA2;
    public Material treeBark_SA2;
    public Material treeLeaves_SA3;
    public Material treeBark_SA3;

    public ParticleSystem[] Sparks_PA1;
    public ParticleSystem[] Sparks_PA2;
    public ParticleSystem[] Sparks_PA3;
    public ParticleSystem[] Sparks_PA4;

    public ParticleSystem[] Sparks_TA1;
    public ParticleSystem[] Sparks_TA2;
    public ParticleSystem[] Sparks_TA3;
    public ParticleSystem[] Sparks_TA4;

    public ParticleSystem[] Sparks_SA1;
    public ParticleSystem[] Sparks_SA2;
    public ParticleSystem[] Sparks_SA3;

    public ParticleSystem[] Sparks_Beach;

    public ParticleSystem[] Fireworks;
    public ParticleSystem[] Confetti;


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

    void Start()
    {
        StartCoroutine(volcanoe());
        ocean.SetActive(false);
    }

    IEnumerator volcanoe(){
        yield return new WaitForSeconds(1.5f);
        volcanoeVFX.playRate = volcanoe_Speed;
    }


    
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
        yield return null;

    }

    IEnumerator Petshop_VFX(){

        foreach (GameObject obj in petshop){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        }
        yield return null; 
    }

    IEnumerator terrain_VFX(){

        foreach (GameObject obj in terrain){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return new WaitForSeconds(0.6f);                  //change this depending on how long u want :o

        foreach (ParticleSystem yuh in Confetti){
            yuh.Play();
        }

        foreach (ParticleSystem yuh in Fireworks){
            yuh.Play();
        }
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
        yield return new WaitForSeconds(0.6f);
        
        Color grassColor = new Color(0f, 255f / 255f, 0f, 1.0f);
        grass_TA1.SetColor("_GrassColor", grassColor);
            
        Color treeBark = new Color(0f, 255f / 255f, 0f, 1.0f);
        treeBark_TA1.color = treeBark;

        Color treeLeaves = new Color(0f / 255f, 100f / 255f, 0f / 255f, 1.0f);
        treeLeaves_TA1.color = treeLeaves;
    }

    IEnumerator townArea2_VFX(){

        foreach (GameObject obj in townArea2){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return new WaitForSeconds(0.6f);

        foreach (ParticleSystem yuh in Sparks_TA2){
            yuh.Play();
        }
        
        Color grassColor = new Color(0f, 255f / 255f, 0f, 1.0f);
        grass_TA2.SetColor("_GrassColor", grassColor);
            
        Color treeBark = new Color(0f, 255f / 255f, 0f, 1.0f);
        treeBark_TA2.color = treeBark;

        Color treeLeaves = new Color(0f / 255f, 100f / 255f, 0f / 255f, 1.0f);
        treeLeaves_TA2.color = treeLeaves;
    }

    IEnumerator townArea3_VFX(){

        foreach (GameObject obj in townArea3){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return new WaitForSeconds(0.6f);
        
        Color grassColor = new Color(0f, 255f / 255f, 0f, 1.0f);
        grass_TA3.SetColor("_GrassColor", grassColor);
            
        Color treeBark = new Color(0f, 255f / 255f, 0f, 1.0f);
        treeBark_TA3.color = treeBark;

        Color treeLeaves = new Color(0f / 255f, 100f / 255f, 0f / 255f, 1.0f);
        treeLeaves_TA3.color = treeLeaves;  
    }

    IEnumerator townArea4_VFX(){
    
        Debug.Log("huh");



        foreach (GameObject obj in townArea4){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return new WaitForSeconds(0.6f);

        foreach (ParticleSystem yuh in Sparks_TA4){
            yuh.Play();
        }
        
        Color grassColor = new Color(0f, 255f / 255f, 0f, 1.0f);
        grass_TA4.SetColor("_GrassColor", grassColor);
            
        Color treeBark = new Color(0f, 255f / 255f, 0f, 1.0f);
        treeBark_TA4.color = treeBark;

        Color treeLeaves = new Color(0f / 255f, 100f / 255f, 0f / 255f, 1.0f);
        treeLeaves_TA4.color = treeLeaves;
    }

    IEnumerator parkArea1_VFX(){

        foreach (GameObject obj in parkArea1){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return new WaitForSeconds(0.6f);

        foreach (ParticleSystem yuh in Sparks_PA1){
            yuh.Play();
        }
        
        Color grassColor = new Color(0f, 255f / 255f, 0f, 1.0f);
        grass_PA1.SetColor("_GrassColor", grassColor);
            
        Color treeBark = new Color(0f, 255f / 255f, 0f, 1.0f);
        treeBark_PA1.color = treeBark;

        Color treeLeaves = new Color(0f / 255f, 100f / 255f, 0f / 255f, 1.0f);
        treeLeaves_PA1.color = treeLeaves;
    }

    IEnumerator parkArea2_VFX(){

        foreach (GameObject obj in parkArea2){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return new WaitForSeconds(0.6f);

        foreach (ParticleSystem yuh in Sparks_PA2){
            yuh.Play();
        }
        
        Color grassColor = new Color(0f, 255f / 255f, 0f, 1.0f);
        grass_PA2.SetColor("_GrassColor", grassColor);
            
        Color treeBark = new Color(0f, 255f / 255f, 0f, 1.0f);
        treeBark_PA2.color = treeBark;

        Color treeLeaves = new Color(0f / 255f, 100f / 255f, 0f / 255f, 1.0f);
        treeLeaves_PA2.color = treeLeaves;
    }

    IEnumerator parkArea3_VFX(){

        foreach (GameObject obj in parkArea3){
            Debug.Log(obj.name);
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return new WaitForSeconds(0.6f);

        foreach (ParticleSystem yuh in Sparks_PA3){
            yuh.Play();
        }
        
        Color grassColor = new Color(0f, 255f / 255f, 0f, 1.0f);
        grass_PA3.SetColor("_GrassColor", grassColor);
            
        Color treeBark = new Color(0f, 255f / 255f, 0f, 1.0f);
        treeBark_PA3.color = treeBark;

        Color treeLeaves = new Color(0f / 255f, 100f / 255f, 0f / 255f, 1.0f);
        treeLeaves_PA3.color = treeLeaves;
    }

    IEnumerator parkArea4_VFX(){

        foreach (GameObject obj in parkArea4){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return new WaitForSeconds(0.6f);

        foreach (ParticleSystem yuh in Sparks_PA4){
            yuh.Play();
        }
        
        Color grassColor = new Color(0f, 255f / 255f, 0f, 1.0f);
        grass_PA4.SetColor("_GrassColor", grassColor);
            
        Color treeBark = new Color(0f, 255f / 255f, 0f, 1.0f);
        treeBark_PA4.color = treeBark;

        Color treeLeaves = new Color(0f / 255f, 100f / 255f, 0f / 255f, 1.0f);
        treeLeaves_PA4.color = treeLeaves;
    }

    IEnumerator sideArea1_VFX(){

        foreach (GameObject obj in sideArea1){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return new WaitForSeconds(0.6f);

        foreach (ParticleSystem yuh in Sparks_SA1){
            yuh.Play();
        }
        
        Color grassColor = new Color(0f, 255f / 255f, 0f, 1.0f);
        grass_SA1.SetColor("_GrassColor", grassColor);
            
        Color treeBark = new Color(0f, 255f / 255f, 0f, 1.0f);
        treeBark_SA1.color = treeBark;

        Color treeLeaves = new Color(0f / 255f, 100f / 255f, 0f / 255f, 1.0f);
        treeLeaves_SA1.color = treeLeaves;
    }

    IEnumerator sideArea2_VFX(){

        foreach (GameObject obj in sideArea2){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return new WaitForSeconds(0.6f);

        foreach (ParticleSystem yuh in Sparks_SA2){
            yuh.Play();
        }
        
        Color grassColor = new Color(0f, 255f / 255f, 0f, 1.0f);
        grass_SA2.SetColor("_GrassColor", grassColor);
            
        Color treeBark = new Color(0f, 255f / 255f, 0f, 1.0f);
        treeBark_SA2.color = treeBark;

        Color treeLeaves = new Color(0f / 255f, 100f / 255f, 0f / 255f, 1.0f);
        treeLeaves_SA2.color = treeLeaves;
    }

    IEnumerator sideArea3_VFX(){

        foreach (GameObject obj in sideArea3){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return new WaitForSeconds(0.6f);

        foreach (ParticleSystem yuh in Sparks_SA3){
            yuh.Play();
        }
        
        Color grassColor = new Color(0f, 255f / 255f, 0f, 1.0f);
        grass_SA3.SetColor("_GrassColor", grassColor);
            
        Color treeBark = new Color(0f, 255f / 255f, 0f, 1.0f);
        treeBark_SA3.color = treeBark;

        Color treeLeaves = new Color(0f / 255f, 100f / 255f, 0f / 255f, 1.0f);
        treeLeaves_SA3.color = treeLeaves;
    }

    IEnumerator beach_VFX(){

        foreach (GameObject obj in beach){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return new WaitForSeconds(0.6f);

        ocean.SetActive(true);

        foreach (ParticleSystem yuh in Sparks_Beach){
            yuh.Play();
        }
    }



    void Update(){

        if (Input.GetKeyDown(KeyCode.F)){
            color_townArea2(); 
        }
    }
}
 