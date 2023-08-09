using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

interface IInteractable
{
    public void Interact();
}

public class Player : MonoBehaviour
{

    public Transform raycastSource;
    public float raycastRange = 5f;
    private void Start()
    {
    }

    private void Update()
    {
    }

   
    void Raycast()
    {
        float debugDuration = 2.0f;

        Ray ray = new Ray(raycastSource.position, raycastSource.forward);
        RaycastHit hitData;
        Debug.DrawRay(ray.origin, ray.direction * raycastRange, Color.red, debugDuration);
        if(Physics.Raycast(ray, out hitData, raycastRange))
        {
            if(hitData.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                interactObj.Interact();
            }
        }
    }

    #region Input Event


    void OnInteract()
    {
        Raycast();
    }
    #endregion
}