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
        /*for(int i = 0; i < objectToSpawn.Count; i++)
        {
            GameObject obj = objectToSpawn[i];
            Transform transform = spawnTransform[i];

            GameObject spawnedObject = Instantiate(obj);
            obj.transform.position = transform.position;
        }*/

        GameObject objecttospawn = Object.Instantiate(objectToSpawn);
        objecttospawn.transform.position = locationToSpawn.position;

    }
}
