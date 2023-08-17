using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int numQuestCompleted;
    private SkyManager skyManager;

    private void Start()
    {
        skyManager = SkyManager.instance;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            numQuestCompleted++;
        }

        if (numQuestCompleted == 3)
        {
            skyManager.ChangeToNoon();
        }
        else if(numQuestCompleted == 5)
        {
            skyManager.ChangeToNight();
        }
    }

    /// <summary>
    /// Rotates the skybox.
    /// </summary>
    public void AddToTime()
    {

    }
}
