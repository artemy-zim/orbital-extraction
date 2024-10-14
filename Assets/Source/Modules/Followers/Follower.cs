using System;
using UnityEngine;

internal abstract class Follower : IFollower
{
    private readonly Vector3 _offset;
    private readonly Transform _transform;
    private ITarget _target;

    public Follower(Transform transform, ITarget target, Vector3 offset)
    {
        _transform = transform != null ? transform : throw new ArgumentNullException(nameof(transform));
        _target = target ?? throw new ArgumentNullException(nameof(target));
        _offset = offset;
    }

    public void SetTarget(ITarget target)
    {
        _target = target;
    }

    public void Follow()
    {
        if (_target == null)
            return;

        Vector3 targetPosition = GetNewPosition();

        TakeStep(_transform, targetPosition);
    }

    private Vector3 GetNewPosition()
    {
        return _target.GetPosition() + _offset;
    }

    protected abstract void TakeStep(Transform transform, Vector3 newPosition);
}
