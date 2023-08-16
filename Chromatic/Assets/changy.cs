using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changy: MonoBehaviour
{
    public GameObject go;
    public Material material;
    private float changeFlash = 0;
    private bool flash = false;
    private bool flashStop = false;

    float red = 255f;
    float green = 255f;
    float blue = 255f;
       
    void Start(){
        go = this.gameObject;
        material = go.GetComponent<MeshRenderer>().material;

        if (go.name == "barrier_gs"){
            StartCoroutine(barrier());
        }
        else{
            StartCoroutine(tryy());
        }
    }


    IEnumerator barrier(){
        float time = 1f;
        yield return new WaitForSeconds(0.1f);
        while (time > 0f){                                    
            material.SetFloat("_Transparency", time);
            time -= Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator tryy(){               // color change 
        float time = 0f;
        float flashtime = 0f;
        float unflashtime = 1f;
        float colortime = 0f;

        while (flashStop == false){ 
            yield return new WaitForSeconds(0.001f);

            if (flashtime < 35f && flash == false){
                material.SetColor("_Flash", Color.white * flashtime);
                flashtime += (Time.deltaTime * 20);      
                Debug.Log("glowing brighter...");               
                yield return null;
            }

            if (flashtime >= 9f){                         //stop before it gets too bright, number gotten from testing
                flash = true;
                Debug.Log("flash stop");

                red -= 1f;
                green -= 1f;
                blue -= 1f;

                Color changeColoring = new Color(red, green, blue);
                material.SetColor("_Flash", changeColoring);    
                material.SetFloat("_Strength", colortime);
                colortime += Time.deltaTime;

                if (red <= 0 && colortime < 1){
                   flashStop = true;
                }  
            yield return null;    
            }

        }
    }

}
