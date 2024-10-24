using UnityEngine;

internal class SmoothFollower : IFollowStrategy
{
    private readonly float _smoothTime;

    private Vector3 _velocity = Vector3.zero;

    public SmoothFollower(float smoothTime)
    {
        _smoothTime = Mathf.Clamp(smoothTime, 0, float.MaxValue);
    }

    public void ApplyMovement(Transform transform, Vector3 targetPosition)
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
    }
}
