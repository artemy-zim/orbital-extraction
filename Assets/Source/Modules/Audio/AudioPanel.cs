using UniRx;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPanel : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;

    private void Awake()
    {
        MessageBroker.Default.Receive<VolumeChangedMessage>()
            .Subscribe(message => ChangeVolume(message.Parameter, message.Value))
            .AddTo(this);
    }

    private void ChangeVolume(string parameterName, float value)
    {
        int volumeScalingFactor = 20;

        _mixer.SetFloat(parameterName, volumeScalingFactor * Mathf.Log10(value));

        PlayerPrefs.SetFloat(parameterName, value);
    }
}
