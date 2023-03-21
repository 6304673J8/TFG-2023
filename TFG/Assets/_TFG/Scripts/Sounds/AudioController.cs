using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private Profiles _profiles;

    [SerializeField]
    private List<SlidersManager> _slidersManager = new List<SlidersManager>();

    private void Awake()
    {
        if (_profiles != null)
            _profiles.SetProfile(_profiles);
    }

    private void Start()
    {
        if (Settings.profile && Settings.profile.audioMixer != null)
            Settings.profile.GetAudioLevels();
    }

    public void ApplyChanges()
    {
        if (Settings.profile && Settings.profile.audioMixer != null)
            Settings.profile.SaveAudioLevels();
    }

    public void CancelChanges()
    {
        if (Settings.profile)
            Settings.profile.GetAudioLevels();
        for (int i = 0; i < _slidersManager.Count; i++)
        {
            _slidersManager[i].ResetSliderValue();
        }
    }
}
