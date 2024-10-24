using System;
using UnityEngine;

internal class Follower 
{
    private readonly Transform _transform;

    private readonly Vector3 _offset;
    private readonly IFollowStrategy _followPolicy;
    private ITarget _target;

    public Follower(Transform transform, ITarget target, Vector3 offset, IFollowStrategy followPolicy)
    {
        _transform = transform != null 
            ? transform 
            : throw new ArgumentNullException(nameof(transform));

        _target = target ?? throw new ArgumentNullException(nameof(target));
        _followPolicy = followPolicy ?? throw new ArgumentNullException(nameof(followPolicy));

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

        Vector3 targetPosition = _target.GetPosition() + _offset;

        _followPolicy.ApplyMovement(_transform, targetPosition);
    }
}
