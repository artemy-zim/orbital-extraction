using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ExitPositionFinder
{
    [SerializeField] private float _distance;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private int _searchStepDegrees;

    private Vector3 _localDirection;

    public void Init()
    {
        _localDirection = new Vector3(_direction.x, 0, _direction.y);
    }

    public Vector3 CalculatePosition(Collider vehicleCollider, Collider driverCollider)
    {
        Vector3 worldDirection = vehicleCollider.transform.TransformDirection(_localDirection);
        Vector3 vehicleCenter = vehicleCollider.bounds.center;
        Vector3 driverCenter = driverCollider.bounds.center;
        float offsetY = driverCenter.y - vehicleCenter.y;

        int maxDegrees = 360;
        int attemptsAmount = maxDegrees / _searchStepDegrees;

        Vector3 exitPosition = vehicleCenter + worldDirection * _distance;
        exitPosition.y += offsetY;

        for (int i = 0; i < attemptsAmount; i++)
        {
            float angle = i * _searchStepDegrees;
            Vector3 rotatedDirection = Quaternion.Euler(0, angle, 0) * worldDirection;

            exitPosition = vehicleCenter + rotatedDirection * _distance;
            exitPosition.y += offsetY;

            if (IsPathAccessible(vehicleCenter, rotatedDirection, _distance, driverCollider))
            {
                break;
            }
        }

        return exitPosition;
    }

    private bool IsPathAccessible(Vector3 vehicleCenter, Vector3 direction, float distance, Collider driverCollider)
    {
        foreach (Vector3 origin in GetRaycastOrigins(vehicleCenter, driverCollider))
        {
            if (Physics.Raycast(origin, direction, out RaycastHit hitInfo, distance, _mask))
            {
                return false;
            }
        }

        return true;
    }

    private IEnumerable<Vector3> GetRaycastOrigins(Vector3 center, Collider driverCollider)
    {
        yield return center;
        yield return center + new Vector3(0, driverCollider.bounds.extents.y, 0);
        yield return center - new Vector3(0, driverCollider.bounds.extents.y, 0);
        yield return center + new Vector3(driverCollider.bounds.extents.x, 0, 0);
        yield return center - new Vector3(driverCollider.bounds.extents.x, 0, 0);
    }
}
