using System.Collections;
using UnityEngine;

public class Gem : MonoBehaviour, ICollectable
{
    [SerializeField] private PhysicsActivator _physicsActivator;
    [SerializeField] private DistanceThresholdChecker _distanceChecker;

    [SerializeField] private float _collectSpeed;
    [SerializeField] private float _collectAcceleration;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void OnCollect(Cell cell)
    {
        if (cell == null)
            return;

        _transform.SetParent(cell.transform);
        _physicsActivator.Deactivate();
        StartCoroutine(FollowCoroutine(cell));
    }

    private IEnumerator FollowCoroutine(ITarget target)
    {
        IFollower follower = new AcceleratingFollower(_transform, target, Vector3.zero, _collectSpeed, _collectAcceleration);
        _distanceChecker.Init(_transform, target);

        while (_distanceChecker.IsFar())
        {
            follower.Follow();

            yield return null;
        }
    }
}
