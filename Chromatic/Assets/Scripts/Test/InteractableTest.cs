using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTest : MonoBehaviour, IInteractable
{
    /// <summary>
    /// Called when player interacts with object.
    /// </summary>
    public void Interact()
    {
        Destroy(gameObject);
        Debug.Log("Interacted");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
