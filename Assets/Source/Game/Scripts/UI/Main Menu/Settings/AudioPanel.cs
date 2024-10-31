using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioPanel : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;

    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _effectsSlider;
    [SerializeField] private Slider _interfaceSlider;
    [SerializeField] private Button _volumeButton;

    private bool _isVolumeOn;

    public event Action<bool> VolumeToggled;

    private void Awake()
    {
        _isVolumeOn = false;
        ToggleVolume();
    }

    private void OnEnable()
    {
        _musicSlider.onValueChanged.AddListener(value => ChangeVolume(AudioMixerData.Params.MusicVolume, value));
        _effectsSlider.onValueChanged.AddListener(value => ChangeVolume(AudioMixerData.Params.EffectsVolume, value));
        _interfaceSlider.onValueChanged.AddListener(value => ChangeVolume(AudioMixerData.Params.InterfaceVolume, value));
        _volumeButton.onClick.AddListener(ToggleVolume);
    }

    private void OnDisable()
    {
        _musicSlider.onValueChanged.RemoveListener(value => ChangeVolume(AudioMixerData.Params.MusicVolume, value));
        _effectsSlider.onValueChanged.RemoveListener(value => ChangeVolume(AudioMixerData.Params.EffectsVolume, value));
        _interfaceSlider.onValueChanged.RemoveListener(value => ChangeVolume(AudioMixerData.Params.InterfaceVolume, value));
        _volumeButton.onClick.RemoveListener(ToggleVolume);
    }

    private void ToggleVolume()
    {
        _isVolumeOn = !_isVolumeOn;
        ChangeVolume(AudioMixerData.Params.MasterVolume, GetToggleValue());

        VolumeToggled?.Invoke(_isVolumeOn);
    }

    private float GetToggleValue()
    {
        float minValue = -80f;
        float maxValue = 0f;

        return _isVolumeOn ? maxValue : minValue;
    }

    private void ChangeVolume(string parameterName, float value)
    {
        int volumeScalingFactor = 20;

        _mixer.SetFloat(parameterName, volumeScalingFactor * Mathf.Log10(value));
    }
}
