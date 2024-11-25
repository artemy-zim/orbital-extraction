using System;
using UnityEngine;

internal class Vehicle : Player
{
    [SerializeField] private ExitPositionFinder _positionFinder;

    private Collider _collider;

    private void Awake()
    {
        _collider = TryGetComponent(out Collider collider) 
            ? collider 
            : throw new ArgumentNullException(nameof(collider));

        _positionFinder.Init();
    }

    public Vector3 GetExitPosition(Collider driverCollider)
    {
        return _positionFinder.CalculatePosition(_collider, driverCollider);
    }
}
