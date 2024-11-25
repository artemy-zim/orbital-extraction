using System;
using UniRx;
using UnityEngine;

internal class RockParticlesPlayer : MonoBehaviour, ISpawnable
{
    [SerializeField] private ParticleSystem _particleSystem;

    public event Action<RockParticlesPlayer> Completed;

    public void OnSpawn()
    {
        _particleSystem.Play();
        
        Observable.EveryUpdate()
            .Where(_ => _particleSystem.isPlaying == false)
            .First()
            .Subscribe(_ => Completed?.Invoke(this))
            .AddTo(this);
    }
}
