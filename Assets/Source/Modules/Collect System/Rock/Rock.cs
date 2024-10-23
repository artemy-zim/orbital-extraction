using System;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class Rock : Resource
{
    [SerializeField] private float _speed;

    protected override IFollower CreateFollower(ITarget target, Transform transform)
    {
        return new LinearFollower(transform, target, Vector3.zero, _speed);
    }
}
