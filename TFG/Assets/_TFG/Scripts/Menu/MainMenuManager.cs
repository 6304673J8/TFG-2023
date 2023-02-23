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
    [SerializeField] Button _exitButton;
    [SerializeField] Button _optionsBackButton;
    [SerializeField] Button _creditsBackButton;
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
        _optionsButton.onClick.AddListener(ToOptions);
        _creditsButton.onClick.AddListener(ToCredits);
        _exitButton.onClick.AddListener(ToExit);
        _optionsBackButton.onClick.AddListener(ToGoBack);
        _creditsBackButton.onClick.AddListener(ToGoBack);
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
            _isCreditsActive = false;
        }
        else if (_isOptionsActive)
        {
            _optionsPanel.SetActive(false);
            _isOptionsActive = false;
        }
    }

    public void ToExit()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}