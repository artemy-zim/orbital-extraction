using System;
using System.Collections.ObjectModel;
using System.Linq;
using UniRx;
using UnityEngine;

internal class GemStorage : Storage
{
    [SerializeField] private float _addDelay;

    protected override void ProcessCollectibles(Collection<ICollectable> collectibles, Action<ICollectable> add)
    {
        IObservable<ICollectable> delayedCollectibles = collectibles.Skip(1)
        .ToObservable()
        .Zip(Observable.Interval(TimeSpan.FromSeconds(_addDelay)),
            (collectible, _) => collectible);

        Observable.Return(collectibles.First())
            .Concat(delayedCollectibles)
            .Subscribe(collectible => add(collectible))
            .AddTo(this);
    }
}
