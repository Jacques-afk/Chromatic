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
    public bool isSprint = false;
    public bool isWalk = false;
    public bool isHappy = false;

    private InterfaceManager ui;

    [Header("Ground Check")]
    public LayerMask isGround;
    bool isGrounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    private Vector3 moveDirection;

    private bool isPaused = false;

    [HideInInspector]
    [Header("Animation")]
    public Animator animator;
    [HideInInspector]
    public Rigidbody rb;

    [Header("Handling Slope")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        // assigns the rigid body
        rb = GetComponent<Rigidbody>();

        //freezes the rotation
        rb.freezeRotation = true;

        //Store the active Interface Manager
        ui = InterfaceManager.instance;
        

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

       // Debug.Log(isWalk);

        HandleAnimation();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }


    private void HandleAnimation()
    {
        //Getting parameter values from animator
        bool isWalking = animator.GetBool("isWalking");
        bool isRunning = animator.GetBool("isRunning");
        bool isJump = animator.GetBool("isJump");

        if (isHappy)
        {
            animator.SetBool("isHappy",true);
        }
        else
        {
            animator.SetBool("isHappy", false);
        }

        if (isSprint)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        if (isWalk)
        {
            animator.SetBool("isWalking",true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        if(canJump == false)
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }
    }

    /// <summary>
    /// Keyboard functions
    /// </summary>
    private void PlayerInput()
    {
        if (!ui.inDialogue)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }

        if(verticalInput != 0)
        {
            if (isSprint)
            {
                isWalk = false;
            }
            else
            {
                isWalk = true;
            }
            
        }
        else if (horizontalInput != 0)
        {
            if (isSprint)
            {
                isWalk = false;
            }
            else
            {
                isWalk = true;
            }
        }
        else
        {
            isWalk = false;
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (!ui.inDialogue)
        {
            if (onSlope())
            {
                rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 13.0f, ForceMode.Force);
            }
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

    private bool onSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, 2f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }
        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

    #region Input Event
    void OnJump()
    {
        if (!ui.inDialogue)
        {
            //Check to see if player is grounded and can jump
            if (isGrounded && canJump)
            {
                canJump = false;
                Jump();
                Invoke(nameof(ResetJump), jumpCooldown);


            }
        }
    }

    void OnSprint()
    {
        if (isWalk || isSprint)
        {
            isSprint = !isSprint;
        }
        
    }

    void OnPause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            ui.ClosePauseMenu();
        }
        else
        {
            ui.OpenPauseMenu();
        }
    }

    #endregion
}
