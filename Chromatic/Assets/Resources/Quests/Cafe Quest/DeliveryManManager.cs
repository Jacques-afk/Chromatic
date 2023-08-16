using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManManager : MonoBehaviour
{

    public NPCScript npc;
    public Behavior_FollowPlayer npcFollow;
    public static DeliveryManManager instance;

    private void Awake()
    {
        instance = this; 
        npcFollow = GetComponent<Behavior_FollowPlayer>();
        npc = GetComponent<NPCScript>();
    }

}
