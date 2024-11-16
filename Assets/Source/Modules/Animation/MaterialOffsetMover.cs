using System;
using UniRx;
using UnityEngine;

public class MaterialOffsetMover : IAnimator
{
    private readonly Material _material;
    private readonly Vector2 _direction;
    private readonly float _speed;
    private readonly float _adjustmentFactor;

    private IDisposable _animationSubscription;

    public MaterialOffsetMover(Material material, Vector2 direction, float speed)
    {
        _material = material;
        _direction = direction;
        _speed = speed;
        _adjustmentFactor = 0.525f;
    }

    public void Play()
    {
        Stop();

        _animationSubscription = Observable.EveryUpdate()
            .Subscribe(_ => _material.mainTextureOffset += _speed * Time.deltaTime * _direction * _adjustmentFactor);
    }

    public void Stop()
    {
        _animationSubscription?.Dispose();
    }
}
