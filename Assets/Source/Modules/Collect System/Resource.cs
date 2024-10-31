using System;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Resource : MonoBehaviour, ICollectable
{
    private PhysicsSwitcher _physicsSwitcher;
    private Transform _transform;
    private Follower _follower;

    private IDisposable _followSubscription;

    private void Awake()
    {
        _transform = transform;
        _physicsSwitcher = new PhysicsSwitcher(GetComponent<Collider>(), GetComponent<Rigidbody>());
    }

    public void OnCollect(Cell cell, IFollowStrategy followStrategy)
    {
        if (cell == null || followStrategy == null)
            return;

        _transform.SetParent(cell.transform);

        _physicsSwitcher.DisablePhysics();
        Follow(cell, followStrategy);

        _transform.rotation = Random.rotation;
    }

    private void Follow(ITarget target, IFollowStrategy followStrategy)
    {
        _follower = new Follower(_transform, target, Vector3.zero, followStrategy);
        _followSubscription?.Dispose();

        _followSubscription = Observable.EveryUpdate()
            .TakeWhile(_ => IsFar(target.GetPosition()))
            .Subscribe(_ => _follower.Follow());
    }

    private bool IsFar(Vector3 targetPosition)
    {
        return Vector3.Distance(targetPosition, _transform.position) > 0;
    }

    private void OnDestroy()
    {
        _followSubscription?.Dispose();
    }
}
