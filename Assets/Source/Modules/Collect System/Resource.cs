using System;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public abstract class Resource : MonoBehaviour, ICollectable
{
    private Collider _collider;
    private Rigidbody _rigidbody;
    private Transform _transform;

    private IDisposable _followSubscription;

    private void Awake()
    {
        _collider = TryGetComponent(out Collider collider) 
            ? collider
            : throw new ArgumentNullException(nameof(collider));

        _rigidbody = TryGetComponent(out Rigidbody rigidbody)
            ? rigidbody
            : throw new ArgumentNullException(nameof(rigidbody));

        _transform = transform;
    }

    public void OnCollect(Cell cell)
    {
        if (cell == null)
            return;

        _transform.SetParent(cell.transform);

        DisablePhysics();
        Follow(cell);
    }

    private void Follow(ITarget target)
    {
        IFollower follower = CreateFollower(target, _transform);
        _followSubscription?.Dispose();

        _followSubscription = Observable.EveryUpdate()
            .TakeWhile(_ => IsFar(target.GetPosition()))
            .Subscribe(_ => follower.Follow());

        _transform.rotation = Random.rotation;
    }

    private void DisablePhysics()
    {
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
    }

    private bool IsFar(Vector3 targetPosition)
    {
        return Vector3.Distance(targetPosition, _transform.position) > 0;
    }

    private void OnDestroy()
    {
        _followSubscription?.Dispose();
    }

    protected abstract IFollower CreateFollower(ITarget target, Transform transform);
}
