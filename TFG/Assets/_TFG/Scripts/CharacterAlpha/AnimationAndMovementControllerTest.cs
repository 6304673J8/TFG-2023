using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationAndMovementControllerTest : MonoBehaviour
{
    public static AnimationAndMovementControllerTest Instance { get; private set; }

    //Future Key Re Binding
    public enum Binding
    {
        Move_Up,
        Move_Down,
        Move_Left,
        Move_Right,
        Interact,
        InteractAlternate,
        Pause,
        Gamepad_Interact,
        Gamepad_InteractAlternate,
        Gamepad_Pause
    }

    //private Renderer _renderer;

    //Declare Reference Variables
    private PlayerInputs _playerInputs;
    private CharacterController _characterController;
    private Animator _animator;

    //Variables To Store Optimized Setter/Getter parameter IDs
    int _isWalkingHash;
    int _isDashingHash;
    int _isJumpingHash;
    int _jumpCountHash;
    int _isIdleHash;

    //Variables To Store Player Input Values
    Vector2 _currentMovementInput;
    Vector3 _currentMovement;
    Vector3 _currentRunMovement;
    Vector3 _appliedMovement;
    bool _isMovementPressed;
    [SerializeField]
    bool _isDashPressed;

    //Constants
    private float _rotationFactorPerFrame = 15.0f;
    [SerializeField]
    private float _runBaseSpeed = 2.0f;

    //Original value = 3.0f
    [SerializeField]
    private float _runMultiplier = 5.0f;
    private int _zero = 0;

    //Gravity 
    private float _gravity = -9.8f;
    private float _groundedGravity = -0.05f;

    //Jump Variables
    [SerializeField]
    bool _isJumping = false;
    [SerializeField]
    bool _isJumpPressed = false;
    bool _isJumpAnimating = false;
    float _initialJumpVelocity;
    //Original value = 4.0f
    [SerializeField]
    float _maxJumpHeight = 2.0f;
    [SerializeField]
    float _maxJumpTime = 0.75f;

    //Jumping Extras Test
    int _jumpCount = 0;
    Dictionary<int, float> _initialJumpVelocities = new Dictionary<int, float>();
    Dictionary<int, float> _initialJumpGravities = new Dictionary<int, float>();
    Coroutine _currentJumpResetRoutine = null;

    #region Initialize

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
        _jumpCountHash = Animator.StringToHash("_jumpCount");

        //Set The Player Input Callbacks
        //WALK
        _playerInputs.CharacterControls.Move.started += OnMovementInput;
        _playerInputs.CharacterControls.Move.performed += OnMovementInput;
        _playerInputs.CharacterControls.Move.canceled += OnMovementInput;
        //RUN
        _playerInputs.CharacterControls.Run.started += OnDashInput;
        _playerInputs.CharacterControls.Run.canceled += OnDashInput;
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

        //This Was Originally _maxJumpHeight + Double
        float _secondJumpGravity = (-2 * (_maxJumpHeight + 1)) / Mathf.Pow((_timeToApex * 1.25f), 2);
        float _secondJumpInitialVelocity = (2 * (_maxJumpHeight + 1)) / (_timeToApex * 1.25f);
        float _thirdJumpGravity = (-2 * (_maxJumpHeight + 2)) / Mathf.Pow((_timeToApex * 1.5f), 2);
        float _thirdJumpInitialVelocity = (2 * (_maxJumpHeight + 2)) / (_timeToApex * 1.5f);

        _initialJumpVelocities.Add(1, _initialJumpVelocity);
        _initialJumpVelocities.Add(2, _secondJumpInitialVelocity);
        _initialJumpVelocities.Add(3, _thirdJumpInitialVelocity);

        _initialJumpGravities.Add(0, _gravity);
        _initialJumpGravities.Add(1, _gravity);
        _initialJumpGravities.Add(2, _secondJumpGravity);
        _initialJumpGravities.Add(3, _thirdJumpGravity);
    }

    #endregion

    #region InputCallbackCtx
    private void OnJumpInput(InputAction.CallbackContext context)
    {
        _isJumpPressed = context.ReadValueAsButton();
        Debug.Log(_isJumpPressed);
    }

    void OnDashInput(InputAction.CallbackContext context)
    {
        _isDashPressed = context.ReadValueAsButton();
    }

    void OnMovementInput (InputAction.CallbackContext context)
    {
        _currentMovementInput = context.ReadValue<Vector2>();
        _currentMovement.x = _currentMovementInput.x * _runBaseSpeed;
        _currentMovement.z = _currentMovementInput.y * _runBaseSpeed;
        _currentRunMovement.x = _currentMovementInput.x * _runMultiplier;
        _currentRunMovement.z = _currentMovementInput.y * _runMultiplier;
        _isMovementPressed = _currentMovementInput.x != _zero || _currentMovementInput.y != _zero;
    }
    #endregion

    #region Handlers

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
        bool _isWalking = _animator.GetBool("isWalking");
        //bool _isRunning = _animator.GetBool("isRunning");
        bool _isJumping = _animator.GetBool("isJumping");
        bool _isDashing = _animator.GetBool("isDashing");
        bool _isIdle = _animator.GetBool("isIdle");

        //Start Walking Animation If MovementPressed Is True And Not Already Walking Else Viceversa
        if (_isMovementPressed && !_isWalking)
        {
            _animator.SetBool(_isWalkingHash, true);
        }
        else if (!_isMovementPressed && _isWalking)
        {
            _animator.SetBool(_isWalkingHash, false);
        }

        if ((_isMovementPressed && _isDashPressed) && !_isDashing)
        {
            _animator.SetBool(_isDashingHash, true);
        }
        else if ((!_isMovementPressed || !_isDashPressed) && _isDashing)
        {
            _animator.SetBool(_isDashingHash, false);
        } 
        /*
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
            if (_jumpCount < 3 && _currentJumpResetRoutine != null)
            {
                StopCoroutine(_currentJumpResetRoutine);
            }
            _animator.SetBool("isJumping", true);
            _isJumpAnimating = true;
            _isJumping = true;
            _jumpCount += 1;
            _animator.SetInteger(_jumpCountHash, _jumpCount);
            _currentMovement.y = _initialJumpVelocities[_jumpCount];
            _appliedMovement.y = _initialJumpVelocities[_jumpCount];
        }
        else if (!_isJumpPressed && _isJumping && _characterController.isGrounded)
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
            if (_isJumpAnimating)
            {
                _animator.SetBool(_isJumpingHash, false);
                _isJumpAnimating = false;
                _currentJumpResetRoutine = StartCoroutine(JumpResetRoutine());
                if (_jumpCount == 3)
                {
                    _jumpCount = 0;
                    _animator.SetInteger(_jumpCountHash, _jumpCount);
                }
            }
            _currentMovement.y = _groundedGravity;
            _appliedMovement.y = _groundedGravity;
        }
        else if (_isFalling)
        {
            float _previousYVelocity = _currentMovement.y;
            _currentMovement.y = _currentMovement.y + (_initialJumpGravities[_jumpCount] * _fallMultiplier * Time.deltaTime);
            //Makes Character Move
            _appliedMovement.y = Mathf.Max((_previousYVelocity + _currentMovement.y) * .5f, -20.0f);
        }
        else
        {
            float _previousYVelocity = _currentMovement.y;
            _currentMovement.y = _currentMovement.y + (_initialJumpGravities[_jumpCount] * Time.deltaTime);
            _appliedMovement.y = (_previousYVelocity + _currentMovement.y) * .5f;
        }
    }

    #endregion

    IEnumerator JumpResetRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        _jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        HandleAnimation();
        if (_isDashPressed)
        {
            _appliedMovement.x = _currentRunMovement.x;
            _appliedMovement.z = _currentRunMovement.z;
        }
        else
        {
            _appliedMovement.x = _currentMovement.x;
            _appliedMovement.z = _currentMovement.z;
        }
        _characterController.Move(_appliedMovement * Time.deltaTime);

        HandleGravity();
        HandleJump();
    }

    #region InputEnableDisable
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

    #endregion
    
    public void ApplyImpulse()
    {
        if (_currentMovement.x == 0 || _currentMovement.x != 0)
            _currentMovement.y = _initialJumpVelocity * 2f;
    } 
}