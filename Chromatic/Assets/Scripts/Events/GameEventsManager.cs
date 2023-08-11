using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    public QuestEvents questEvents;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //Initialize all events
        }

        questEvents = new QuestEvents();



    }
}
