using System;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Rock : Resource, ITarget
{
    private readonly CompositeDisposable _disposables = new();

    private Collider _collider;
    private Transform _transform;

    private void Awake()
    {
        _collider = TryGetComponent(out Collider collider) 
            ? collider 
            : throw new ArgumentNullException(nameof(collider));

        _transform = transform;
    }

    private void OnEnable()
    {
        CollectedObservable
            .Subscribe(_ => _transform.rotation = UnityEngine.Random.rotation)
            .AddTo(_disposables);
    }

    private void OnDisable()
    {
        _disposables.Clear();
    }

    public Vector3 GetPosition()
    {
        return _transform.position;
    }

    protected override void DisablePhysics()
    {
        _collider.enabled = false;
    }

    protected override void EnablePhysics()
    {
        _collider.enabled = true;
    }
}