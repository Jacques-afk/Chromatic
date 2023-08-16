using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuestManager : MonoBehaviour
{
    [HideInInspector]
    public NPCScript npc;
    [HideInInspector]
    public Behavior_FollowPlayer npcFollow;
    public static NPCQuestManager instance;

    private void Awake()
    {
        instance = this; 
        npcFollow = GetComponent<Behavior_FollowPlayer>();
        npc = GetComponent<NPCScript>();
    }

    public void DestroyNPC()
    {
        StartCoroutine(DestroyBody());
    }

    IEnumerator DestroyBody()
    { 
        yield return new WaitForSeconds(10);

        Destroy(this.gameObject);
    }

    public void DestroySelf()
    {
        Destroy(this);
    }
}
