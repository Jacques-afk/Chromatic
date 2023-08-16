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
        StartCoroutine(tryy());
    }

    IEnumerator tryy(){
        
        float time = 0;
        yield return new WaitForSeconds(0.1f);
            while (time < 1f)
            {
                material.SetFloat("_Strength", time);
                time += Time.deltaTime;
                yield return null;
            }
    }

}
