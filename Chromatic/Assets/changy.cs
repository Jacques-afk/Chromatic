using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changy: MonoBehaviour
{
    public GameObject go;
    public Material material;
    public float rateOf_Decrease = 2f;

    private bool flash = false;
    private bool flashStop = false;
    private Color currentColor;
    private Color createdColor;

    
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
                Debug.Log("increase start");               
                yield return null;
            }

            if (flashtime >= 9f){                         //stop before it gets too bright, number gotten from testing
                flash = true;
                Debug.Log("decrease start");
                currentColor = material.GetColor("_Flash");

                currentColor.r -= rateOf_Decrease;
                currentColor.g -= rateOf_Decrease;
                currentColor.b -= rateOf_Decrease;

                // var factor = 1.1f;
                // createdColor = new Color(currentColor.r * factor, currentColor.g * factor, currentColor.b * factor, currentColor.a);

                material.SetColor("_Flash", createdColor);    
                material.SetFloat("_Strength", colortime);
                colortime += Time.deltaTime;


                if (material.GetFloat("_Strength") >= 1){
                    material.SetFloat("_Strength", 1f);
                }

                if (currentColor.r <= 0){
                   flashStop = true;
                }   
            }

        }
    }

}
