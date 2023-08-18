using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[SerializeField] private List<GameObject> objectToSpawn = new List<GameObject>();
    //[SerializeField] private List<Transform> spawnTransform = new List<Transform>();

    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Transform locationToSpawn;


    public void SpawnObject()
    {
        GameObject objecttospawn = Object.Instantiate(objectToSpawn);
        objecttospawn.transform.position = locationToSpawn.position;
        objecttospawn.transform.position = locationToSpawn.position;

    }
}
