using System;
using System.Collections.Generic;
using UnityEngine;

internal class RockStorage : Storage
{
    [SerializeField] private float _speed;

    protected override IFollowStrategy CreatePolicy()
    {
        return new LinearFollower(_speed);
    }

    protected override void ProcessCollectibles(IReadOnlyCollection<ICollectable> collectibles, Action<ICollectable> Add)
    {
        foreach (var collectable in collectibles)
        {
            Add(collectable);
        }
    }
}
