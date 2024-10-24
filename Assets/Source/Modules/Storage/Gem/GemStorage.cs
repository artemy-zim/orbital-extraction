using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

internal class GemStorage : Storage
{
    [SerializeField] private Vector3 _curveAmplitude;
    [SerializeField] private float _speed;

    [SerializeField] private float _addDelay;

    protected override IFollowStrategy CreatePolicy()
    {
        return new CurveFollower(_speed, _curveAmplitude);
    }

    protected override void ProcessCollectibles(IReadOnlyCollection<ICollectable> collectibles, Action<ICollectable> Add)
    {
        IObservable<ICollectable> delayedCollectibles = collectibles.Skip(1)
        .ToObservable()
        .Zip(Observable.Interval(TimeSpan.FromSeconds(_addDelay)),
            (collectible, _) => collectible);

        Observable.Return(collectibles.First())
            .Concat(delayedCollectibles)
            .Subscribe(collectible => Add(collectible))
            .AddTo(this);
    }
}
