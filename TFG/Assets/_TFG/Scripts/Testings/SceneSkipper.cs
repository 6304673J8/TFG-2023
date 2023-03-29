using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneSkipper : MonoBehaviour
{
    private PlayerInputs _playerInputs;

    [SerializeField]
    bool _isPreviousPressed;

    [SerializeField]
    bool _isNextPressed;

    //SusanaController susanaController;
    private void Awake()
    {
        _playerInputs = new PlayerInputs();

        //PREVIOUS SCENE
        _playerInputs.CharacterControls.PreviousScene.started += OnPreviousSceneInput;
        _playerInputs.CharacterControls.PreviousScene.canceled += OnPreviousSceneInput;

        //NEXT SCENE
        _playerInputs.CharacterControls.NextScene.started += OnNextSceneInput;
        _playerInputs.CharacterControls.NextScene.canceled += OnNextSceneInput;
    }

    #region InputCallbackCtx
    private void OnPreviousSceneInput(InputAction.CallbackContext context)
    {
        Debug.Log("Pressing Previous Scene");
        _isPreviousPressed = context.ReadValueAsButton();
    }

    private void OnNextSceneInput(InputAction.CallbackContext context)
    {
        _isNextPressed = context.ReadValueAsButton();
    }
    #endregion

    private void Update()
    {
        if (_isNextPressed)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else if (_isPreviousPressed)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}