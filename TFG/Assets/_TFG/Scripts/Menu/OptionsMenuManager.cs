using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.PlayerLoop;

public class OptionsMenuManager : MonoBehaviour
{
    private bool _isFullScreen;
    
    //Add Camera Settings
    //[Header("Camera")]

    [Header("Audio")] 
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private TMP_InputField _musicInputField;
    [SerializeField] private TMP_InputField _sfxInputField;

    [Header("Graphics")] 
    [SerializeField] private Toggle _fullScreenToggle;

    private const string _musicHash = "SfxVolume";
    private const string _sfxHash = "MusicVolume";
    private const string _sensibilityXTag = "SensibilityX";
    private const string _sensibilityYTag = "SensibilityY";
    private const string _invertedX = "InvertedX";
    private const string _invertedY = "InvertedY";

    private const int _defaultVelocityX = 200;
    private const int _defaultVelocityy = 3;

    [Header("Animations")] [SerializeField]
    private GameObject _menuAnimationManager;

    private Animator _animator;

    private void Awake()
    {
        if (_menuAnimationManager)
        {
            _animator = _menuAnimationManager.GetComponent<Animator>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (_menuAnimationManager)
        {
            _animator.SetBool("isIdle", true);
        }
        UIEvents();
        LoadSettings();
    }

    private void UIEvents()
    {
        //Camera ToDo
    }
    
    //ButtonsAnimation
    public void ButtonClick()
    {
        _animator.SetBool("isIdle", false);
        _animator.SetBool("isReturning", false);
        _animator.SetBool("isSelected", true);
    }
    
    public void SaveButtonClick()
    {
        _animator.SetBool("isIdle", false);
        _animator.SetBool("isReturning", false);
        _animator.SetBool("isSelected", true);
    }

    public void LoadSettings()
    {
        //ToImplement
    }
    
    #region Graphics

    public void SetFullScreenBool(bool _value)
    {
        PlayerPrefs.SetInt("FullScreen", _value ? 1 : 0);
        Screen.fullScreen = _value;
    }
    
    #endregion
    
    #region Audio

    public void ChangeSfxVolumeInput(string _value)
    {
        if (float.TryParse(_value, out float _sfxVolume))
        {
            if (_sfxVolume > 100)
            {
                _sfxVolume = 100;
                _sfxInputField.text = "100";
            }
            else if (_sfxVolume < 0)
            {
                _sfxVolume = 0;
                _sfxInputField.text = "0";
            }
            
            PlayerPrefs.SetFloat(_sfxHash, _sfxVolume);
            _sfxSlider.value = _sfxVolume;
            print(_sfxVolume);
        }
    }
    
    public void ChangeMusicVolumeInput(string _value)
    {
        if (float.TryParse(_value, out float _musicVolume))
        {
            if (_musicVolume > 100)
            {
                _musicVolume = 100;
                _musicInputField.text = "100";
            }
            else if (_musicVolume < 0)
            {
                _musicVolume = 0;
                _musicInputField.text = "0";
            }
            
            PlayerPrefs.SetFloat(_musicHash, _musicVolume);
            _musicSlider.value = _musicVolume;
            print(_musicVolume);
        }
    }
    
    public void ChangeMusicVolumeSlider(float _value)
    {
        PlayerPrefs.SetFloat(_musicHash, _musicSlider.value);
        _musicInputField.text = _value.ToString();
        //AkSoundEngine.SetRTPCValue("Volume_Music", _musicSlider.value)
    }
    
    public void ChangeSfxVolumeSlider(float _value)
    {
        PlayerPrefs.SetFloat(_sfxHash, _sfxSlider.value);
        _sfxInputField.text = _value.ToString();
        //AkSoundEngine.SetRTPCValue("Volume_SFX", _sfxSlider.value)
    }
    
    #endregion
    
    #region Getters

    public bool GetFullScreen()
    {
        return Screen.fullScreen;
    }
    #endregion
}
