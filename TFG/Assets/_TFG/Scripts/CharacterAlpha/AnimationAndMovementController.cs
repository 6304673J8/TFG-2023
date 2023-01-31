using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationAndMovementController : MonoBehaviour
{
    //Declare Reference Variables
    private PlayerInputs _playerInputs;
    private CharacterController _characterController;
    private Animator _animator;

    //Variables To Store Optimized Setter/Getter parameter IDs
    int _isWalkingHash;
    int _isRunningHash;

    //Variables To Store Player Input Values
    Vector2 _currentMovementInput;
    Vector3 _currentMovement;
    Vector3 _currentRunMovement;
    bool _isMovementPressed;
    bool _isRunPressed;

    //Constants
    private float _rotationFactorPerFrame = 15.0f;
    private float _runMultiplier = 3.0f;
    private int _zero = 0;
    private float _gravity = -9.8f;
    private float groundedGravity = -0.05f;
    
    //Jump Variables
    bool _isJumpPressed = false;

    private void Awake()
    {
        //Set Reference Variables
        _playerInputs = new PlayerInputs();
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _isWalkingHash = Animator.StringToHash("isWalking");
        _isRunningHash = Animator.StringToHash("isRunning");
        /* Once Final Character Is Ready
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        */

        //Ask If This Is Ideal Or Better To Create A Manager!!!
        //Set The Player Input Callbacks
        _playerInputs.CharacterControls.Move.started += OnMovementInput;
        _playerInputs.CharacterControls.Move.performed += OnMovementInput;
        _playerInputs.CharacterControls.Move.canceled += OnMovementInput;

        _playerInputs.CharacterControls.Run.started += OnRunInput;
        _playerInputs.CharacterControls.Run.canceled += OnRunInput;

        _playerInputs.CharacterControls.Jump.started += OnJumpInput;
        _playerInputs.CharacterControls.Jump.canceled += OnJumpInput;
    }

    private void OnJumpInput(InputAction.CallbackContext context)
    {
        _isJumpPressed = context.ReadValueAsButton();
        Debug.Log(_isJumpPressed);
    }

    void OnRunInput(InputAction.CallbackContext context)
    {
        _isRunPressed = context.ReadValueAsButton();
    }

    void OnMovementInput (InputAction.CallbackContext context)
    {
        _currentMovementInput = context.ReadValue<Vector2>();
        _currentMovement.x = _currentMovementInput.x;
        _currentMovement.z = _currentMovementInput.y;
        _currentRunMovement.x = _currentMovementInput.x * _runMultiplier;
        _currentRunMovement.y = _currentMovementInput.y * _runMultiplier;
        _currentRunMovement.z = _currentMovementInput.y * _runMultiplier;
        _isMovementPressed = _currentMovementInput.x != 0 || _currentMovementInput.y != 0;
    }

    void HandleRotation()
    {
        Vector3 positionToLookAt;
        //Where Our Character Should Reposition To
        positionToLookAt.x = _currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = _currentMovement.z;
        //The Current Rotation Of Our Character
        Quaternion currentRotation = transform.rotation;

        if (_isMovementPressed)
        {
            //Creates A New Rotations Based On The Input That The Player Is Pressing
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _rotationFactorPerFrame * Time.deltaTime);
        }
    }

    void HandleAnimation()
    {
        //Get Parameter Values From Animator
        bool isWalking = _animator.GetBool(_isWalkingHash);
        bool isRunning = _animator.GetBool(_isRunningHash);

        //Start Walking Animation If MovementPressed Is True And Not Already Walking Else Viceversa
        if (_isMovementPressed && !isWalking)
        {
            _animator.SetBool("isWalking", true);
        }
        else if (!_isMovementPressed && isWalking)
        {
            _animator.SetBool("isWalking", false);
        }

        if ((_isMovementPressed && _isRunPressed) && !isRunning)
        {
            _animator.SetBool(_isRunningHash, true);
        }
        else if ((!_isMovementPressed || !_isRunPressed) && isRunning)
        {
            _animator.SetBool(_isRunningHash, false);
        }
    }

    void HandleGravity()
    {
        if (_characterController.isGrounded)
        {
            float groundedGravity = -.05f;
            _currentMovement.y = groundedGravity;
            _currentRunMovement.y = groundedGravity;
        }
        else
        {
            float gravity = -9.8f;
            _currentMovement.y += gravity;
            _currentRunMovement.y += gravity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleGravity();
        HandleRotation();
        //HandleAnimation();

        if (_isRunPressed)
        {
            _characterController.Move(_currentMovement * Time.deltaTime);
        }
        else
        {
            _characterController.Move(_currentMovement * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        // enable the character controls action map
        _playerInputs.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        // disable the character controls action map
        _playerInputs.CharacterControls.Disable();
    }
}
