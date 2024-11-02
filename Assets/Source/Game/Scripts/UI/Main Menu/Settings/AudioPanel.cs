using UnityEngine;
using UnityEngine.Audio;

public class AudioPanel : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;

    [SerializeField] private MusicVolume _musicVolume;
    [SerializeField] private EffectsVolume _effectsVolume;
    [SerializeField] private InterfaceVolume _interfaceVolume;
    [SerializeField] private MasterVolume _masterVolume;

    private void OnEnable()
    {
        _musicVolume.Changed += ChangeVolume;
        _effectsVolume.Changed += ChangeVolume;
        _interfaceVolume.Changed += ChangeVolume;
        _masterVolume.Changed += ChangeVolume;
    }

    private void OnDisable()
    {
        _musicVolume.Changed -= ChangeVolume;
        _effectsVolume.Changed -= ChangeVolume;
        _interfaceVolume.Changed -= ChangeVolume;
        _masterVolume.Changed -= ChangeVolume;
    }

    private void ChangeVolume(string parameterName, float value)
    {
        int volumeScalingFactor = 20;

        _mixer.SetFloat(parameterName, volumeScalingFactor * Mathf.Log10(value));

        PlayerPrefs.SetFloat(parameterName, value);
    }
}
