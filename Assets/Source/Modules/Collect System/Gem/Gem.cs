using System.Collections;
using UnityEngine;

public class Gem : MonoBehaviour, ICollectable, ISpawnable
{
    [SerializeField] private PhysicsActivator _physicsActivator;
    [SerializeField] private DistanceThresholdChecker _distanceChecker;

    [SerializeField] private float _collectSpeed;
    [SerializeField] private float _collectAcceleration;

    public void OnCollect(ITarget collector)
    {
        if (collector == null)
            return;

        _physicsActivator.Deactivate();
        StartCoroutine(FollowCoroutine(collector));
    }

    public void OnSpawn()
    {
        throw new System.NotImplementedException();
    }

    public void OnDespawn()
    {
        throw new System.NotImplementedException();
    }

    private IEnumerator FollowCoroutine(ITarget target)
    {
        IFollower follower = new AcceleratingFollower(transform, target, Vector3.zero, _collectSpeed, _collectAcceleration);
        _distanceChecker.Init(transform, target);

        while (_distanceChecker.IsFar())
        {
            follower.Follow();

            yield return null;
        }

        _physicsActivator.Activate();
        Destroy(gameObject);
    }
}
