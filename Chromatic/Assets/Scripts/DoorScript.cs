using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private GameObject player;
    public Transform nextDoorTransform;
    public float offsetTransform;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.instance;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void StartDoorTimer()
    {
        StartCoroutine(TeleportPlayer());
        audioManager.PlaySound(audioManager.doorOpen);
    }
    public IEnumerator TeleportPlayer()
    {
        yield return new WaitForSeconds(0.5f);

        player.transform.position = nextDoorTransform.position;

        yield return new WaitForSeconds(0.5f);
        audioManager.PlaySound(audioManager.doorClose);
    }
}
