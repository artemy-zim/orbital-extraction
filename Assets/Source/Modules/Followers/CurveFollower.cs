using TMPro;
using UnityEngine;

public class CurveFollower : IFollowStrategy
{
    private const float ProgressMaxValue = 1f;
    private const float ProgressMinValue = 0f;

    private readonly Vector3 _curveAmplitude;
    private readonly float _speed;

    private Vector3 _startPosition;
    private Vector3 _currentTargetPosition;
    private float _progress;

    public CurveFollower(float speed, Vector3 curveAmplitude)
    {
        _speed = Mathf.Clamp(speed, 0, float.MaxValue);
        _curveAmplitude = curveAmplitude;
    }

    public void ApplyMovement(Transform transform, Vector3 targetPosition)
    {
        UpdateStartPosition(transform, targetPosition);

        _progress += _speed * Time.deltaTime;

        if (_progress >= ProgressMaxValue)
        {
            transform.position = _currentTargetPosition;
            _progress = ProgressMinValue;

            return;
        }

        transform.position = CalculateNewPosition();
    }

    private void UpdateStartPosition(Transform transform, Vector3 targetPosition)
    {
        if (targetPosition != _currentTargetPosition)
        {
            _startPosition += targetPosition - _currentTargetPosition;
            _currentTargetPosition = targetPosition;
        }

        if (_progress == ProgressMinValue)
        {
            _startPosition = transform.position;
            _currentTargetPosition = targetPosition;
        }
    }

    private Vector3 CalculateNewPosition()
    {
        Vector3 newPosition = Vector3.Lerp(_startPosition, _currentTargetPosition, _progress);

        Vector3 curveOffset = new(
            Mathf.Sin(Mathf.PI * _progress) * _curveAmplitude.x,
            Mathf.Sin(Mathf.PI * _progress) * _curveAmplitude.y,
            Mathf.Sin(Mathf.PI * _progress) * _curveAmplitude.z
        );

        return newPosition + curveOffset;
    }
}

