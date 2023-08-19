using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is attached to each gameobject to change its color or reduce transparency if its a barrier
/// </summary>
public class changy : MonoBehaviour
{
    /// <summary>
    /// Reference to the GameObject this script is attached too and material.
    /// </summary>
    public GameObject go;
    public Material material;

    /// <summary>
    /// Rate of transparency decrease for the barrier GameObject.
    /// </summary>
    public float rateOf_Decrease = 2f;

    private bool flash = false;
    private bool flashStop = false;
    private Color currentColor;
    private Color createdColor;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        go = this.gameObject;
        material = go.GetComponent<MeshRenderer>().material;

        // Choose which coroutine to run based on the GameObject's name
        if (go.name == "barrier_gs")
        {
            StartCoroutine(DecreaseTransparencyCoroutine());
        }
        else
        {
            StartCoroutine(ColorChangeCoroutine());
        }
    }

    /// <summary>
    /// Coroutine that gradually decreases transparency of the material for the barrier GameObject.
    /// </summary>
    /// <returns>IEnumerator used for coroutine execution.</returns>
    IEnumerator DecreaseTransparencyCoroutine()
    {
        float time = 1f;
        yield return new WaitForSeconds(1f);

        while (time > 0f)
        {                                    
            material.SetFloat("_Transparency", time);
            time -= Time.deltaTime;
            yield return null;
        }
    }

    /// <summary>
    /// Coroutine that handles color change and flashing effect for non-barrier GameObjects.
    /// </summary>
    /// <returns>IEnumerator used for coroutine execution.</returns>
    IEnumerator ColorChangeCoroutine()
    {
        float time = 0f;
        float flashtime = 0f;
        float unflashtime = 1f;
        float colortime = 0f;

        while (flashStop == false)
        { 
            yield return new WaitForSeconds(0.001f);

            if (flashtime < 35f && flash == false)
            {
                material.SetColor("_Flash", Color.white * (flashtime / 2));   
                flashtime += (Time.deltaTime * 40);       
            }

            if (flashtime >= 9f)
            {                        
                flash = true;
                Color change = Color.Lerp(material.GetColor("_Flash"), Color.black, 0.05f);
                material.SetColor("_Flash", change);   
                material.SetFloat("_Strength", colortime);
                colortime += Time.deltaTime;
                Debug.Log("happy happy happy");

                float strength = material.GetFloat("_Strength");

                if (strength > 1.2f){   //value here is how satured you want you're color to be :0
                    flashStop = true;
                } 
            }
        }
    }
}
