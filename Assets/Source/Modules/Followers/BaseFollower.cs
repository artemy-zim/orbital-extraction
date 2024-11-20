using System;
using UniRx;
using UnityEngine;

internal abstract class BaseFollower : IFollowStrategy
{
    private readonly ITarget _target;
    private readonly Vector3 _offset;
    private readonly IFollowStrategy _innerFollower;

    private IDisposable _followSubscription;

    protected BaseFollower(ITarget target, Vector3 offset, IFollowStrategy innerFollower = null)
    {
        _target = target ?? throw new ArgumentNullException(nameof(target));
        _innerFollower = innerFollower;
        _offset = offset;
    }

    public void Follow(Transform transform, UpdateMode mode)
    {
        if (transform == null) 
            return;

        Stop();

        _followSubscription = GetObservableUpdate(mode)
            .TakeWhile(_ => IsFar(transform))
            .Subscribe(_ => Move(transform, GetFinalPosition()),
                       () => _innerFollower?.Follow(transform, mode));
    }

    public void Stop()
    {
        _followSubscription?.Dispose();
        _innerFollower?.Stop();
    }

    private bool IsFar(Transform transform)
    {
        float epsilon = 0.0001f;

        return Vector3.Distance(GetFinalPosition(), transform.position) > epsilon;
    }

    private Vector3 GetFinalPosition()
    {
        return _target.GetPosition() + _offset;
    }

    private IObservable<long> GetObservableUpdate(UpdateMode mode)
    {
        return mode switch
        {
            UpdateMode.EveryUpdate => Observable.EveryUpdate(),
            UpdateMode.EveryLateUpdate => Observable.EveryLateUpdate(),
            _ => Observable.EveryUpdate()
        };
    }

    protected abstract void Move(Transform transform, Vector3 targetPosition);
}
