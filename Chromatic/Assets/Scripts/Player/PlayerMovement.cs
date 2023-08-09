using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movment")]
    public float moveSpeed;
    public float sprintSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMulitplier;
    private bool canJump = true;
    private bool isSprint = false;

    [Header("Ground Check")]
    public LayerMask isGround;
    bool isGrounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        // assigns the rigid body
        rb = GetComponent<Rigidbody>();

        //freezes the rotation
        rb.freezeRotation = true;

    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 2f, isGround);
        //Debug.Log(isGrounded);
        PlayerInput();

        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    /// <summary>
    /// Keyboard functions
    /// </summary>
    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (isGrounded)
        {
            if (isSprint)
            {
                rb.AddForce(moveDirection.normalized * sprintSpeed * 13.0f, ForceMode.Force);
            }
            else
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * 13.0f, ForceMode.Force);
            }
            
        }
        else
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10.0f * airMulitplier, ForceMode.Force);
        }
        
    }

    private void SpeedClamp()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (isSprint)
        {
            if (flatVelocity.magnitude > moveSpeed)
            {
                Vector3 clampedVelocity = flatVelocity.normalized * moveSpeed;
                rb.velocity = new Vector3(clampedVelocity.x, rb.velocity.y, clampedVelocity.z);
            }
            else
            {
                Vector3 clampedVelocity = flatVelocity.normalized * sprintSpeed;
                rb.velocity = new Vector3(clampedVelocity.x, rb.velocity.y, clampedVelocity.z);
            }
        }
        
    }

    /// <summary>
    /// Allows the player to jump, by resetting the Y velocity and applying jump force.
    /// </summary>
    private void Jump()
    {
        //Resets the Y Velocity so jump will be consistant.
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //Apply the jump force.
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

    }

    private void ResetJump()
    {
        canJump = true;
    }

    #region Input Event
    void OnJump()
    {
        Debug.Log("JUMP!");

        //Check to see if player is grounded and can jump
        if (isGrounded && canJump)
        {
            canJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);

            
        }
    }

    void OnSprint()
    {
        isSprint = !isSprint;
    }

    #endregion
}