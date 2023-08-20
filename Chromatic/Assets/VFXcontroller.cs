using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXcontroller : MonoBehaviour
{

     /// <summary>
    /// Reference to objects in a certain area by tag, visual effects and particle systems.
    /// </summary>

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

    public VisualEffect [] Sparks_Beach;

    public VisualEffect[] Fireworks;       //visual effects and particles
    public ParticleSystem[] Confetti;
    public ParticleSystem[] Wind;

    public Color white;
    public Color black;
    public Color grey;

    public Color lightGreen;
    public Color mediumGreen;
    public Color darkGreen;
    public Color lightOrange;
    public Color mediumOrange; 

    /// <summary>
    /// Reference to the falling leaves particles.
    /// </summary>

    public ParticleSystem[] Falling_PA1;
    public ParticleSystem[] Falling_PA2;
    public ParticleSystem[] Falling_PA3;
    public ParticleSystem[] Falling_PA4;

    public ParticleSystem[] Falling_TA1;
    public ParticleSystem[] Falling_TA2;
    public ParticleSystem[] Falling_TA3;
    public ParticleSystem[] Falling_TA4;

    public ParticleSystem[] Falling_SA1;
    public ParticleSystem[] Falling_SA2;
    public ParticleSystem[] Falling_SA3;

    /// <summary>
    /// Instantiate script and find objects related to certain areas via the tags mentioned below.
    /// </summary>


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

    /// <summary>
    /// Dissabling ocean and pond due to clipping issues and decreasing volcano vfx playbackrate.
    /// </summary>

    void Start()
    {
        StartCoroutine(volcanoe());
        ocean.SetActive(false);       //to solve ocean shader not being greyscaled and dissapearing issue
        pond.SetActive(false);        //same issue with ocean

        foreach (VisualEffect yuh in Fireworks){
            yuh.Stop();                            //stop the final cutscene fireworks from playing
        }

        colorNature_grey(); //to present all nature things to a black and white scale
    }

    IEnumerator volcanoe(){
        yield return new WaitForSeconds(1.5f);
        volcanoeVFX.playRate = volcanoe_Speed;
    }

    /// <summary>
    /// Applying randomness to wind to make it seem more natural.
    /// </summary>

    IEnumerator windApply(){

        foreach (ParticleSystem yuh in Wind){
            int randomInt = Random.Range(0,14);
            yield return new WaitForSeconds(randomInt);
            yuh.Play();
        }

    }

    /// <summary>
    /// Below are a list of functions which the player can call in order to color a specific area. Each function is tied to a coroutine.
    /// </summary>
 
    public void colorNature_grey(){
        grass_TA1.SetColor("_GrassColor", grey); 
        treeLeaves_TA1.color = grey;
        treeBark_TA1.color = black;
        grass_TA2.SetColor("_GrassColor", grey);
        treeLeaves_TA2.color = grey;
        treeBark_TA2.color = black;
        grass_TA3.SetColor("_GrassColor", grey);
        treeLeaves_TA3.color = grey;
        treeBark_TA3.color = black;
        grass_TA4.SetColor("_GrassColor", grey);
        treeLeaves_TA4.color = grey;
        treeBark_TA4.color = black;

        grass_PA1.SetColor("_GrassColor", grey);
        treeLeaves_PA1.color = grey;
        treeBark_PA1.color = black;
        grass_PA2.SetColor("_GrassColor", grey);
        treeLeaves_PA2.color = grey;
        treeBark_PA2.color = black;
        grass_PA3.SetColor("_GrassColor", grey);
        treeLeaves_PA3.color = grey;
        treeBark_PA3.color = black;
        grass_PA4.SetColor("_GrassColor", grey);
        treeLeaves_PA4.color = grey;
        treeBark_PA4.color = black;

        grass_SA1.SetColor("_GrassColor", grey);
        treeLeaves_SA1.color = grey;
        treeBark_SA1.color = black;
        grass_SA2.SetColor("_GrassColor", grey);
        treeLeaves_SA2.color = grey;
        treeBark_SA2.color = black;
        grass_SA3.SetColor("_GrassColor", grey);
        treeLeaves_SA3.color = grey;
        treeBark_SA3.color = black;
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

    public void final(){
        StartCoroutine(color_final());
    }

    /// <summary>
    /// For almost every coroutine, below is the base functionality of activiating the color changing script stored inside each itme.
    /// </summary>

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

    /// <summary>
    /// Used for final cutscene of the game where required to remove remaining greyscale effect and play visual effects.
    /// </summary>

    IEnumerator terrain_VFX(){

        yield return new WaitForSeconds(3f);  //halfway zooming out from terrain

        foreach (GameObject obj in terrain){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return new WaitForSeconds(0.6f);                  //change this depending on how long u want when it is zooming out 

        foreach (VisualEffect yuh in Fireworks){      
            yuh.Play();
        }

        // you can add duration here if you want to pause either effect

        foreach (ParticleSystem yuh in Confetti){
            yuh.Play();
        }
    }

    /// <summary>
    /// Color MC house.
    /// </summary>

    IEnumerator MChouse_VFX(){

        foreach (GameObject obj in MChome){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return null;
    }

    /// <summary>
    /// All the code from each function now becomes repetitve, targetting the color changing script, waiting awhile and then playing the particles and changing the nature color in the area.
    /// </summary>

    IEnumerator townArea1_VFX(){

        /// <summary>
        /// Targets the color changing script inside each object with a texture in the area.
        /// </summary>

        foreach (GameObject obj in townArea1){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return new WaitForSeconds(0.6f);
        
        /// <summary>
        /// Play particles, sparks and leaves, related to the area.
        /// </summary>

        foreach (ParticleSystem yuh in Sparks_TA1){
            yuh.Play();
        }

        foreach (ParticleSystem yuo in Falling_TA1){
            yuo.Play();
            yuo.playbackSpeed = 0.5f;
        }

        /// <summary>
        /// Change the color of the trees and grass in that area.
        /// </summary>

        grass_TA1.SetColor("_GrassColor", mediumGreen);
        treeBark_TA1.color = white;
        treeLeaves_TA1.color = mediumGreen;
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

        foreach (ParticleSystem yuo in Falling_TA2){
            yuo.Play();
            yuo.playbackSpeed = 0.5f;
        }
        
        grass_TA2.SetColor("_GrassColor", lightGreen);
        treeBark_TA2.color = white;
        treeLeaves_TA2.color = lightGreen;
    }

    IEnumerator townArea3_VFX(){

        foreach (GameObject obj in townArea3){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return new WaitForSeconds(0.6f);

        foreach (ParticleSystem yuh in Sparks_TA3){
            yuh.Play();
        }

        foreach (ParticleSystem yuo in Falling_TA3){
            yuo.Play();
            yuo.playbackSpeed = 0.5f;
        }

       
        grass_TA3.SetColor("_GrassColor", mediumGreen); 
        treeBark_TA3.color = white;
        treeLeaves_TA3.color = mediumOrange;  
    }

    IEnumerator townArea4_VFX(){

        foreach (GameObject obj in townArea4){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return new WaitForSeconds(0.6f);

        foreach (ParticleSystem yuh in Sparks_TA4){
            yuh.Play();
        }

        foreach (ParticleSystem yuo in Falling_TA4){
            yuo.Play();
            yuo.playbackSpeed = 0.5f;
        }

        grass_TA4.SetColor("_GrassColor", mediumGreen);
        treeBark_TA4.color = white;
        treeLeaves_TA4.color = darkGreen;
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

        foreach (ParticleSystem yuo in Falling_PA1){
            yuo.Play();
            yuo.playbackSpeed = 0.5f;
        }
  
        grass_PA1.SetColor("_GrassColor", mediumGreen);
        treeBark_PA1.color = white;
        treeLeaves_PA1.color = lightOrange;
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

        foreach (ParticleSystem yuo in Falling_PA2){
            yuo.Play();
            yuo.playbackSpeed = 0.5f;
        }
        
        grass_PA2.SetColor("_GrassColor", mediumGreen);
        treeBark_PA2.color = white;
        treeLeaves_PA2.color = mediumGreen;
    }

    IEnumerator parkArea3_VFX(){

        foreach (GameObject obj in parkArea3){
            Debug.Log(obj.name);
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return new WaitForSeconds(0.6f);

        pond.SetActive(true);
        fakePond.SetActive(false);

        foreach (ParticleSystem yuh in Sparks_PA3){
            yuh.Play();
        }

        foreach (ParticleSystem yuo in Falling_PA3){
            yuo.Play();
            yuo.playbackSpeed = 0.5f;
        }
        

        grass_PA3.SetColor("_GrassColor", darkGreen);
        treeBark_PA3.color = white;
        treeLeaves_PA3.color = mediumGreen;
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

        foreach (ParticleSystem yuo in Falling_PA4){
            yuo.Play();
            yuo.playbackSpeed = 0.5f;
        }
        

        grass_PA4.SetColor("_GrassColor", mediumGreen);
        treeBark_PA4.color = white;
        treeLeaves_PA4.color = mediumGreen;
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

        foreach (ParticleSystem yuo in Falling_SA1){
            yuo.Play();
            yuo.playbackSpeed = 0.5f;
        }
        

        grass_SA1.SetColor("_GrassColor", lightGreen);
        treeBark_SA1.color = white;
        treeLeaves_SA1.color = lightGreen;
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

        foreach (ParticleSystem yuo in Falling_SA2){
            yuo.Play();
            yuo.playbackSpeed = 0.5f;
        }
        
 
        grass_SA2.SetColor("_GrassColor", lightGreen);
        treeBark_SA2.color = white;
        treeLeaves_SA2.color = mediumGreen;
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

        foreach (ParticleSystem yuo in Falling_SA3){
            yuo.Play();
            yuo.playbackSpeed = 0.5f;
        }
        
        grass_SA3.SetColor("_GrassColor", darkGreen);
        treeBark_SA3.color = white;
        treeLeaves_SA3.color = mediumGreen;
    }

    IEnumerator beach_VFX(){

        foreach (GameObject obj in beach){
            changy colorswap = obj.GetComponent<changy>();
            colorswap.enabled = true;
        } 
        yield return new WaitForSeconds(0.6f);

        ocean.SetActive(true);
        fakeOcean.SetActive(false);

        foreach (VisualEffect yuh in Sparks_Beach){
            yuh.Play();
        }

        yield return new WaitForSeconds(3f);

        foreach (VisualEffect yuh in Sparks_Beach){
            yuh.Stop();
        }
    }

    /// <summary>
    /// Can call upon this function to help make it easier for the final cutscene.
    /// </summary>

    IEnumerator color_final(){

        yield return new WaitForSeconds(1f);    //change this depending on how long from cutscene u want house to change color
        color_mcHouse();

        yield return new WaitForSeconds(5f);   //when u want the remaining terrain + skybox to change
        color_terrain();
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.L)){
            color_townArea1();
            color_townArea2();
            color_townArea3();
            color_townArea4();

            color_parkArea1();
            color_parkArea2();
            color_parkArea3();
            color_parkArea4();

            color_sideArea1();
            color_sideArea2();
            color_sideArea3();
        }
    }
}
 