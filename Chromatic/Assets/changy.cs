using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changy: MonoBehaviour
{
    public GameObject go;
    public Material material;
       
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


    IEnumerator tryy(){   
        float time = 0;
        yield return new WaitForSeconds(0.1f);

        while (time < 1f){      //1f makes it so it wont go above the value 1 for the shader
            material.SetFloat("_Strength", time);
            time += Time.deltaTime;
            yield return null;
        }
    }


}
