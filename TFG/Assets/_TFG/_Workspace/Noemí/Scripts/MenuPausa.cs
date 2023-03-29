using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuPausa : MonoBehaviour
{
    // [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    private bool juegoPausado = false;

    private PlayerInputs _playerInputs;

    [SerializeField]
    bool _isPausePressed;

    private void Awake()
    {
        _playerInputs = new PlayerInputs();

        //PAUSE
        _playerInputs.CharacterControls.Pause.started += OnPauseInput;
        _playerInputs.CharacterControls.Pause.canceled += OnPauseInput;
    }

    #region InputCallbackCtx
    private void OnPauseInput(InputAction.CallbackContext context)
    {
        _isPausePressed = context.ReadValueAsButton();
    }
    #endregion

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || _isPausePressed)
        {
            
            if(juegoPausado)
            {
                Renaudar();
            }
            else
            {
                Pausa();
            }
        }
    }


    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        // botonPausa.SetActive(false);
        menuPausa.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Renaudar()
    {
       juegoPausado = false;
        Time.timeScale = 1f;
        // botonPausa.SetActive(true);
        menuPausa.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Debug.Log("Renaudar");
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Reiniciar");

    }

    public void Cerrar()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void volverMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
