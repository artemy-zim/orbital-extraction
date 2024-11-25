using System;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Gem : Resource, ISpawnable
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private ImpulseApplier _impulseApplier;

    private Rigidbody _rigidbody;
    private Collider _collider;

    private void Awake()
    {
        _collider = TryGetComponent(out Collider collider) 
            ? collider 
            : throw new ArgumentNullException(nameof(collider));

        _rigidbody = TryGetComponent(out Rigidbody rigidbody)
            ? rigidbody
            : throw new ArgumentNullException(nameof(rigidbody));

        CollectedObservable
            .Subscribe(_ => StopParticles())
            .AddTo(this);
    }

    public void OnSpawn()
    {
        _impulseApplier.GiveImpulse(_rigidbody);
        _particleSystem.Play();
    }

    private void StopParticles()
    {
        if (_particleSystem.isPlaying)
        {
            _particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }

    protected override void DisablePhysics()
    {
        _rigidbody.isKinematic = true;
        _collider.enabled = false;
    }

    protected override void EnablePhysics()
    {
        _rigidbody.isKinematic = false;
        _collider.enabled = true;
    }
}