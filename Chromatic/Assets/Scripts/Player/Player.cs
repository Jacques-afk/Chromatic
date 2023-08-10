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
    private bool isInteract = false;
    private void Start()
    {
    }

    private void Update()
    {
        Raycast();
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
                if (isInteract)
                {
                    interactObj.Interact();
                }
            }
        }
    }

    #region Input Event


    void OnInteract()
    {
        isInteract = !isInteract;
        Debug.Log(isInteract);
    }
    #endregion
}