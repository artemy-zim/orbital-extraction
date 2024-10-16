using UnityEngine;

internal class Vehicle : Player
{
    [SerializeField] private Transform _exitPoint;

    public Vector3 ExitPosition => _exitPoint.position;
}
