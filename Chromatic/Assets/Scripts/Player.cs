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
    Vector3 movementInput = Vector3.zero;

    public float playerMoveSpeed = 10.0f;

    public Transform raycastSource;
    public float raycastRange = 5f;

    public Transform orientation;
    public Transform playerObject;

    float horizontalInput;
    float verticalInput;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        Movement();
    }

    /// <summary>
    /// Controls the movement of the player. Walking and Sprinting.
    /// </summary>
    private void Movement()
    {
        float moveSpeed = playerMoveSpeed;

        // Create a new Vector3
        Vector3 movementVector = Vector3.zero;

        // Add the forward direction of the player multiplied by the user's up/down input.
        movementVector += orientation.forward* movementInput.y;

        // Add the right direction of the player multiplied by the user's right/left input.
        movementVector += orientation.right * movementInput.x;

        // Apply the movement vector multiplied by movement speed to the player's position.
        transform.position += movementVector * moveSpeed * Time.deltaTime;


        //MoveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
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

    void OnMove(InputValue x)
    {
        movementInput = x.Get<Vector2>();
    }

    void OnLook(InputValue x)
    {
        //rotationInput.y = x.Get<Vector2>().x;
        //headRotationInput.x = x.Get<Vector2>().y * -1;
    }

    void OnInteract()
    {
        Raycast();
    }
    #endregion
}