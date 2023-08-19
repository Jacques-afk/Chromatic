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
        yield return new WaitForSeconds(1f);
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

                material.SetColor("_Flash", Color.white * (flashtime / 2));   //divide by how much you want the bloom to lessen
                flashtime += (Time.deltaTime * 40);       //the larger the number the faster it is
                Debug.Log("increase start");               
                yield return null;
            }

            if (flashtime >= 9f){                         //stop before it gets too bright, number gotten from testing
                flash = true;

                Color change = Color.Lerp(material.GetColor("_Flash"), Color.black, 0.01f);

                material.SetColor("_Flash", change);   
                material.SetFloat("_Strength", colortime);
                colortime += Time.deltaTime;


                if (material.GetFloat("_Strength") >= 1){
                    material.SetFloat("_Strength", 1f);
                }  
            }

        }
    }

}
