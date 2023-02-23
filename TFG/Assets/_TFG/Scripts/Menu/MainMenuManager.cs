using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private bool _isCreditsActive;
    private bool _isOptionsActive;

    [Header("Play Game")]
    [SerializeField] Button _playButton;
    [SerializeField] string _tutorialScene;
    [Header("Buttons")]
    [SerializeField] Button _optionsButton;
    [SerializeField] Button _creditsButton; 
    [SerializeField] Button _backButton;
    [Header("Panels")]
    [SerializeField] GameObject _initialPanel;
    [SerializeField] GameObject _optionsPanel;
    [SerializeField] GameObject _creditsPanel;
    //[Header("Panels")]
    //[SerializeField] GameObject _fullScreenActive;
    
    //[Header("Music")]
    //[SerializeField] BackgroundMusic _bgMusic;

    void Start()
    {
        _isOptionsActive = false;
        _isCreditsActive = false;

        _playButton.onClick.AddListener(Play);
        _optionsButton.onCLick.AddListener(ToOptions);
        _creditsButton.onCLick.AddListener(ToCredits);
        _backButton.onCLick.AddListener(ToGoBack);

        // Cursor.lockState = CursorLockMode.None;
        //     Cursor.visible = true;
    }
    
    public void Play()
    {
        //_bgMusic.StopMusic();
        SceneManager.LoadScene(_tutorialScene);
    }

    // Toggles The Options Panel
    public void ToOptions()
    {
        _isOptionsActive = true; 
        _initialPanel.SetActive(false);
        _optionsPanel.SetActive(true);
    }

    // Toggles The Credits Panel
    public void ToCredits()
    {
        _isCreditsActive = true;
        _initialPanel.SetActive(false);
        _creditsPanel.SetActive(true);
    }

    // Goes Back To The Initial Panel
    public void ToGoBack()
    {
        _initialPanel.SetActive(true);
        if (_isCreditsActive)
        {
            _creditsPanel.SetActive(false);
        }
        else if (_isOptionsActive)
        {
            _optionsPanel.SetActive(false);
        }
    }

    // Changes Full Screen If Active
    public void ToggleFullScreen()
    {

    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Salir");
    }
}