using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationAndMovementController : MonoBehaviour
{
    //Declare Reference Variables
    PlayerInputs playerInputs;
    CharacterController characterController;
    Animator animator;

    //Variables To Store Optimized Setter/Getter parameter IDs
    int isWalkingHash;
    int isRunningHash;

    //Variables To Store Player Input Values
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunMovement;
    bool isMovementPressed;
    bool isRunPressed;
    float rotationFactorPerFrame = 1.0f;
    float runMultiplier = 6.0f;

    //Jump Variables
    bool isJumpPressed = false;

    private void Awake()
    {
        //Set Reference Variables
        playerInputs = new PlayerInputs();
        characterController = GetComponent<CharacterController>();
        /* Once Final Character Is Ready
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        */

        //Ask If This Is Ideal Or Better To Create A Manager!!!
        //Set The Player Input Callbacks
        playerInputs.CharacterControls.Move.started += OnMovementInput;
        playerInputs.CharacterControls.Move.performed += OnMovementInput;
        playerInputs.CharacterControls.Move.canceled += OnMovementInput;

        playerInputs.CharacterControls.Run.started += OnRunInput;
        playerInputs.CharacterControls.Run.canceled += OnRunInput;

        playerInputs.CharacterControls.Jump.started += OnJumpInput;
        playerInputs.CharacterControls.Jump.canceled += OnJumpInput;
    }

    private void OnJumpInput(InputAction.CallbackContext context)
    {
        isJumpPressed = context.ReadValueAsButton();
        Debug.Log(isJumpPressed);
    }

    void OnRunInput(InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();
    }

    void OnMovementInput (InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        currentRunMovement.x = currentMovementInput.x * runMultiplier;
        currentRunMovement.y = currentMovementInput.y * runMultiplier;
        currentRunMovement.z = currentMovementInput.y * runMultiplier;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    void HandleRotation()
    {
        Vector3 positionToLookAt;
        //Where Our Character Should Reposition To
        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;
        //The Current Rotation Of Our Character
        Quaternion currentRotation = transform.rotation;

        if (isMovementPressed)
        {
            //Creates A New Rotations Based On The Input That The Player Is Pressing
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }
    }

    void HandleAnimation()
    {
        //Get Parameter Values From Animator
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);

        //Start Walking Animation If MovementPressed Is True And Not Already Walking Else Viceversa
        if (isMovementPressed && !isWalking)
        {
            animator.SetBool("isWalking", true);
        }
        else if (!isMovementPressed && isWalking)
        {
            animator.SetBool("isWalking", false);
        }

        if ((isMovementPressed && isRunPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }
        else if ((!isMovementPressed || !isRunPressed) && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    void HandleGravity()
    {
        if (characterController.isGrounded)
        {
            float groundedGravity = -.05f;
            currentMovement.y = groundedGravity;
            currentRunMovement.y = groundedGravity;
        }
        else
        {
            float gravity = -9.8f;
            currentMovement.y += gravity;
            currentRunMovement.y += gravity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleGravity();
        HandleRotation();
        //HandleAnimation();

        if (isRunPressed)
        {
            characterController.Move(currentMovement * Time.deltaTime);
        }
        else
        {
            characterController.Move(currentMovement * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        // enable the character controls action map
        playerInputs.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        // disable the character controls action map
        playerInputs.CharacterControls.Disable();
    }
}
