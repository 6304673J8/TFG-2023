using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerUpHandler : MonoBehaviour
{
    public Renderer _playerRenderer;

    public event EventHandler<OnSelectedInteractableChangedEventArgs> OnSelectedInteractableChanged;

    public class OnSelectedInteractableChangedEventArgs : EventArgs
    {
        public BaseInteractable selectedInteractable;
    }

    //Declare Reference Variables
    private PlayerInputs _playerInputs;

    //Interact
    bool _isInteractPressed;
    private Vector3 _lastInteractDir;
    [SerializeField]
    private LayerMask interactablesLayerMask;

    //PowerUp Green
    //Boxes
    private BaseInteractable _selectedInteractable;
    [SerializeField] private Transform boxObjectHoldPoint;

    #region Interactable

    private void Awake()
    {
        _playerInputs = new PlayerInputs();

        //Interact
        _playerInputs.CharacterControls.Interact.started += OnInteractInput;
        _playerInputs.CharacterControls.Interact.canceled += OnInteractInput;

    }

    private void OnInteractInput(InputAction.CallbackContext context)
    {
        _isInteractPressed = context.ReadValueAsButton();
        Debug.Log(_isInteractPressed);
    }

    public void PowerUpActivation(int powerUpColor)
    {
        Debug.Log("Activated Power Up" + powerUpColor);
    }
    
    //Future Implementation For Color Restoring Objects
    /*private void Update()
    {
        HandleInteractions();
    }

    void HandleInteractions()
    {
        if (_isInteractPressed)
        {
            Debug.Log("Interacting");
            float interactDistance = 2f;

            if (Physics.Raycast(transform.position, _lastInteractDir, out RaycastHit raycastHit, interactDistance, interactablesLayerMask))
            {
                Debug.Log("Found Interactable");
                if (raycastHit.transform.TryGetComponent(out BaseInteractable baseInteractable))
                {
                    // Has ClearCounter
                    if (baseInteractable != _selectedInteractable)
                    {
                        SetSelectedInteractable(baseInteractable);
                    }
                }
                else
                {
                    SetSelectedInteractable(null);

                }
            }
            else
            {
                SetSelectedInteractable(null);
            }
        }
    }
*/
    private void SetSelectedInteractable(BaseInteractable selectedInteractable)
    {
        this._selectedInteractable = selectedInteractable;

        OnSelectedInteractableChanged?.Invoke(this, new OnSelectedInteractableChangedEventArgs
        {
            selectedInteractable = _selectedInteractable
        });
    }

    public Transform GetObjectFollowTransform()
    {
        return boxObjectHoldPoint;
    }
    
    #endregion
}
