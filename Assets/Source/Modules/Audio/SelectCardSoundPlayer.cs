using System;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SelectCardSoundPlayer : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = TryGetComponent(out AudioSource audioSource) 
            ? audioSource 
            : throw new ArgumentNullException(nameof(audioSource));

        MessageBroker.Default.Receive<TimerCardSelectedMessage>()
            .Subscribe(_ => _audioSource.Play())
            .AddTo(this);
    }
}
