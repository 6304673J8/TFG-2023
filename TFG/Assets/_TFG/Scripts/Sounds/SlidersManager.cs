using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

[RequireComponent(typeof(Slider))]
public class SlidersManager : MonoBehaviour
{
    Slider slider
    {
        get {return GetComponent<Slider>();}
    }

    [Header("Volume Name")]
    [Tooltip("This Is The Name Of The Exposed Parameter")]
    [SerializeField]
    private string volumeName = "Enter Volume Name Here";

    [Header("Volume Label")]
    [SerializeField]
    private TMP_InputField volumeLabel;

    private void Start()
    {
        ResetSliderValue();

        slider.onValueChanged.AddListener(delegate
        {
            UpdateValueOnChange(slider.value);
        });
    }

    public void UpdateValueOnChange(float value)
    {
        if (volumeLabel != null)
            volumeLabel.text = Mathf.Round(value * 100.0f).ToString();
        if (Settings.profile)
        {
            Settings.profile.SetAudioLevels(volumeName, value);
        }
    }

    public void ResetSliderValue()
    {
        if (Settings.profile)
        {
            float volume = Settings.profile.GetAudioLevels(volumeName);

            UpdateValueOnChange(volume);
            slider.value = volume;
        }
    }
}