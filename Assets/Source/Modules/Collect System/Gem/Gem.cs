using System;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class Gem : Resource
{
    [SerializeField] private float _collectSpeed;
    [SerializeField] private float _collectAcceleration;

    private IDisposable _followSubscription;

    protected override void Follow(ITarget target, Transform transform)
    {
        IFollower follower = new AcceleratingFollower(transform, target, Vector3.zero, _collectSpeed, _collectAcceleration);

        _followSubscription?.Dispose();

        _followSubscription = Observable.EveryUpdate()
            .TakeWhile
            (
                _ => IsFar(target.GetPosition(), transform.position)
            )
            .Subscribe
            (
                _ => follower.Follow(),
                () => transform.rotation = Random.rotation
            );
    }

    private bool IsFar(Vector3 targetPosition, Vector3 position)
    {
        return Vector3.Distance(targetPosition, position) > 0;
    }

    private void OnDestroy()
    {
        _followSubscription?.Dispose();
    }
}
