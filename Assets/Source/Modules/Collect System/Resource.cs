using System;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class Resource : MonoBehaviour, ICollectable
{
    [SerializeField] private PhysicsSwitcher _physicsSwitcher;

    private Transform _transform;

    private Follower _follower;

    private IDisposable _followSubscription;

    private void Awake()
    {
        _transform = transform;
    }

    public void OnCollect(Cell cell, IFollowStrategy followPolicy)
    {
        if (cell == null || followPolicy == null)
            return;

        _transform.SetParent(cell.transform);

        _physicsSwitcher.DisablePhysics();
        Follow(cell, followPolicy);

        _transform.rotation = Random.rotation;
    }

    private void Follow(ITarget target, IFollowStrategy followPolicy)
    {
        _follower = new Follower(_transform, target, Vector3.zero, followPolicy);
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
