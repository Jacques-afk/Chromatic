using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SkyManager : MonoBehaviour
{
    public float skyRotateSpeed = 1;
    public Cubemap dayCubeMap;
    public Cubemap noonCubeMap;
    public Cubemap nightCubeMap;
    public float fadeDuration = 3f;

    public Cubemap initialCubeMap;
    private Cubemap targetCubeMap;
    private float startTime;
    private bool fading = false;

    public Transform directionalLight;

    public static SkyManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        initialCubeMap = dayCubeMap;
        UnityEngine.RenderSettings.skybox.SetTexture("_Tex", initialCubeMap);

    }


    // Update is called once per frame
    void Update()
    {
        // Rotates the skybox
        UnityEngine.RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyRotateSpeed);


        /*
        if (directionalLight != null)
        {
            float angle = Mathf.Abs(directionalLight.rotation.eulerAngles.x);
            if (angle > 90f) // Night threshold
            {
                Debug.Log("night to day");
                StartNightToDayTransition();
            }
            else if (angle < 10f) // Day threshold
            {
                Debug.Log("Day to noon");
                StartDayToNoonTransition();
            }
            else // In between (noon) threshold
            {
                Debug.Log("Noon to night");
                StartNoonToNightTransition();
            }
        }*/
    }

    public void ChangeToNoon()
    {
        UnityEngine.RenderSettings.skybox.SetTexture("_Tex", noonCubeMap);
    }

    public void ChangeToNight()
    {
        UnityEngine.RenderSettings.skybox.SetTexture("_Tex", nightCubeMap);
    }

    public void ChangeToDay()
    {
        UnityEngine.RenderSettings.skybox.SetTexture("_Tex", dayCubeMap);
    }
}
