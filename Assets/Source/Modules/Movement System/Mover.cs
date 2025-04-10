using System;
using UnityEngine;

internal class Mover : MonoBehaviour, IMovable, IMoverEvents
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;

    private Transform _transform;
    private Vector3 _direction;
    private Vector2 _previousDirection;

    public event Action Started;
    public event Action Stopped;
    public event Action<float> Rotated;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (_direction == Vector3.zero)
            return;

        Rotate();
        Move();
    }

    public virtual void SetDirection(Vector2 direction)
    {
        _direction = new Vector3(direction.x, _direction.y, direction.y);

        TryCallEvent(direction);

        _previousDirection = direction;
    }

    private void TryCallEvent(Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            Stopped?.Invoke();
        }
        else if (_previousDirection == Vector2.zero)
        {
            Started?.Invoke();
        }
    }

    private void Rotate()
    {
        Quaternion targetRotation = Quaternion.LookRotation(_direction, Vector3.up);
        Quaternion deltaRotation = targetRotation * Quaternion.Inverse(_transform.localRotation);

        _transform.rotation = Quaternion.Lerp(_transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        deltaRotation.ToAngleAxis(out float angle, out Vector3 axis);

        float sign = Mathf.Sign(Vector3.Dot(axis, Vector3.up));
        float maxTurnAngle = 180f;
        float maxAngle = 360f;

        if (angle > maxTurnAngle)
            angle -= maxAngle;

        float normalizedAngle = Mathf.Clamp(angle / maxTurnAngle, -1f, 1f);

        Rotated?.Invoke(sign * normalizedAngle);
    }

    private void Move()
    {
        _transform.Translate(_movementSpeed * Time.deltaTime * _direction, Space.World);
    }
}
