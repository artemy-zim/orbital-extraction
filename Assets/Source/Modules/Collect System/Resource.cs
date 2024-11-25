using System;
using UniRx;
using UnityEngine;

public abstract class Resource : MonoBehaviour, ICollectable, IDestroyable
{
    private readonly Subject<Unit> _collectedSubject = new();
    private IFollowStrategy _currentFollower;

    protected IObservable<Unit> CollectedObservable => _collectedSubject;

    public void OnCollectFollow(Transform parentTransform, IFollowStrategy followStrategy)
    {
        if (parentTransform == null || followStrategy == null)
            return;

        DisablePhysics();
        transform.SetParent(parentTransform);
        _collectedSubject.OnNext(Unit.Default);

        Follow(followStrategy);
    }

    public void OnDestroyFollow(IFollowStrategy followStrategy)
    {
        if (followStrategy == null)
            return;

        EnablePhysics();
        Follow(followStrategy);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void Follow(IFollowStrategy followStrategy)
    {
        _currentFollower?.Stop();
        _currentFollower = followStrategy;
        followStrategy.Follow(transform, UpdateMode.EveryUpdate);
    }

    private void OnDestroy()
    {
        _currentFollower?.Stop();
    }

    protected abstract void DisablePhysics();
    protected abstract void EnablePhysics();
}
