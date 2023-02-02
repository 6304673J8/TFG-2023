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
    int _isDashingHash;
    int _isJumpingHash;
    int _isIdleHash;

    //Variables To Store Player Input Values
    Vector2 _currentMovementInput;
    Vector3 _currentMovement;
    Vector3 _currentRunMovement;
    bool _isMovementPressed;
    [SerializeField]
    bool _isRunPressed;

    //Constants
    private float _rotationFactorPerFrame = 15.0f;
    private float _runMultiplier = 3.0f;
    private int _zero = 0;

    //Gravity 
    private float _gravity = -9.8f;
    private float _groundedGravity = -0.05f;

    //Jump Variables
    [SerializeField]
    bool _isJumping = false;
    [SerializeField]
    bool _isJumpPressed = false;
    float _initialJumpVelocity;
    float _maxJumpHeight = 4.0f;
    float _maxJumpTime = 0.5f;

    private void Awake()
    {
        //Set Reference Variables
        _playerInputs = new PlayerInputs();
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _isWalkingHash = Animator.StringToHash("isWalking");
        _isDashingHash = Animator.StringToHash("isDashing");
        _isJumpingHash = Animator.StringToHash("isJumping");
        _isIdleHash = Animator.StringToHash("isIdle");

        //Set The Player Input Callbacks
        //WALK
        _playerInputs.CharacterControls.Move.started += OnMovementInput;
        _playerInputs.CharacterControls.Move.performed += OnMovementInput;
        _playerInputs.CharacterControls.Move.canceled += OnMovementInput;
        //RUN
        _playerInputs.CharacterControls.Run.started += OnRunInput;
        _playerInputs.CharacterControls.Run.canceled += OnRunInput;
        //JUMP
        _playerInputs.CharacterControls.Jump.started += OnJumpInput;
        _playerInputs.CharacterControls.Jump.canceled += OnJumpInput;

        SetupJumpVariables();
    }

    private void SetupJumpVariables()
    {
        float _timeToApex = _maxJumpTime / 2;
        _gravity = (-2 * _maxJumpHeight) / Mathf.Pow(_timeToApex, 2);
        _initialJumpVelocity = (2 * _maxJumpHeight) / _timeToApex;
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
        _currentRunMovement.z = _currentMovementInput.y * _runMultiplier;
        _isMovementPressed = _currentMovementInput.x != _zero || _currentMovementInput.y != _zero;
    }


    void HandleRotation()
    {
        Vector3 positionToLookAt;
        //Where Our Character Should Reposition To
        positionToLookAt.x = _currentMovement.x;
        positionToLookAt.y = _zero;
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
        bool isWalking = _animator.GetBool("isWalking");
        bool isRunning = _animator.GetBool("isJumping");
        bool isDashing = _animator.GetBool("isDashing");
        bool isIdle = _animator.GetBool("isIdle");

        //Start Walking Animation If MovementPressed Is True And Not Already Walking Else Viceversa
        if (_isMovementPressed && !isWalking)
        {
            _animator.SetBool(_isWalkingHash, true);
        }
        else if (!_isMovementPressed && isWalking)
        {
            _animator.SetBool(_isWalkingHash, false);
        }

        /*if ((_isMovementPressed && _isJumpPressed) && !isRunning)
        {
            _animator.SetBool(_isJumpingHash, true);
        }
        else if ((!_isMovementPressed || !_isJumpPressed) && isRunning)
        {
            _animator.SetBool(_isRunningHash, false);
        }

        if ((_isMovementPressed && _isJumpPressed) && !isRunning)
        {
            _animator.SetBool(_isRunningHash, true);
        }
        else if ((!_isMovementPressed || !_isJumpPressed) && isRunning)
        {
            _animator.SetBool(_isRunningHash, false);
        }*/
    }

    void HandleJump()
    {
        if (!_isJumping && _characterController.isGrounded && _isJumpPressed)
        {
            _isJumping = true;
            _currentMovement.y = _initialJumpVelocity * 0.5f;
            _currentRunMovement.y = _initialJumpVelocity * 0.5f;
        }
        else if (!_isJumpPressed && _isJumping && !_characterController.isGrounded)
        {
            _isJumping = false;
        }
    }
    void HandleGravity()
    {
        bool _isFalling = _currentMovement.y <= 0.0f || !_isJumpPressed;
        float _fallMultiplier = 2.0f;

        if (_characterController.isGrounded)
        {
            _currentMovement.y = _groundedGravity;
            _currentRunMovement.y = _groundedGravity;
        }
        else if (_isFalling) 
        {
            float _previousYVelocity = _currentMovement.y;
            float _newYVelocity = _currentMovement.y + (_gravity * _fallMultiplier * Time.deltaTime);
            float _nextYVelocity = Mathf.Max((_previousYVelocity + _newYVelocity) * .5f, -20.0f);
            _currentMovement.y = _nextYVelocity;
            _currentRunMovement.y = _nextYVelocity;
        }
        /*else
        {
            float _previousYVelocity = _currentMovement.y;
            float _newYVelocity = _currentMovement.y + (_gravity * Time.deltaTime);
            float _nextYVelocity = (_previousYVelocity + _newYVelocity) * .5f;
            _currentMovement.y += _nextYVelocity;
            _currentRunMovement.y += _nextYVelocity;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        HandleAnimation();

        if (_isRunPressed)
        {
            _characterController.Move(_currentRunMovement * Time.deltaTime);
        }
        else
        {
            _characterController.Move(_currentMovement * Time.deltaTime);
        }
        HandleGravity();
        HandleJump();
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
