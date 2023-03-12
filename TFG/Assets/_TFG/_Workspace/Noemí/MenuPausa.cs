using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    // [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    private bool juegoPausado = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
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
        SceneManager.LoadScene(0);
    }
}
