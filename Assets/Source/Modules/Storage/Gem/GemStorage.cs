using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

internal class GemStorage : Storage
{
    [SerializeField] private Vector3 _curveAmplitude;
    [SerializeField] private float _speed;

    [SerializeField] private float _addDelay;

    [SerializeField] private UnityEvent _onAdded;

    protected override IFollowStrategy CreateStrategy(ITarget target)
    {
        return new CurveFollower(target, Vector3.zero, _speed, _curveAmplitude);
    }

    protected override void ProcessCollectibles(IReadOnlyCollection<ICollectable> collectibles, Action<ICollectable> Add)
    {
        IObservable<ICollectable> delayedCollectibles = collectibles.Skip(1)
        .ToObservable()
        .Zip(Observable.Interval(TimeSpan.FromSeconds(_addDelay)),
            (collectible, _) => collectible);

        Observable.Return(collectibles.First())
            .Concat(delayedCollectibles)
            .Subscribe(collectible => ProcessCollectible(collectible, Add))
            .AddTo(this);
    }

    private void ProcessCollectible(ICollectable collectible, Action<ICollectable> Add) 
    {
        Add(collectible);
        _onAdded?.Invoke();
    }
}
