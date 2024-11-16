using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

internal class RockStorage : Storage
{
    [SerializeField] private float _speed;

    [SerializeField] private UnityEvent _onAdded;

    public event Action Stored;

    protected override IFollowStrategy CreateStrategy(ITarget target)
    {
        return new LinearFollower(target, Vector3.zero, _speed);
    }

    protected override void ProcessCollectibles(IReadOnlyCollection<ICollectable> collectibles, Action<ICollectable> Add)
    {
        foreach (var collectable in collectibles)
        {
            Add(collectable);
        }

        _onAdded?.Invoke();
        Stored?.Invoke();
    }
}
