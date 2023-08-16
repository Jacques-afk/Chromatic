using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDMFollow : MonoBehaviour
{
    private NPCScript npc;
    private Behavior_FollowPlayer npcFollowBehavior;

    private void Awake()
    {
        npc = GetComponent<NPCScript>();
        npcFollowBehavior = GetComponent<Behavior_FollowPlayer>();
    }
}
