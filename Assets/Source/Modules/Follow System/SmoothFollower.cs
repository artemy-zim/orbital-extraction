using UnityEngine;

internal class SmoothFollower : Follower
{
    private readonly float _smoothTime;

    private Vector3 _velocity = Vector3.zero;

    public SmoothFollower(Transform transform, ICameraTarget target, Vector3 offset, float smoothTime) : base(transform, target, offset)
    {
        _smoothTime = smoothTime;
    }

    protected override void TakeStep(Transform transform, Vector3 newPosition)
    {
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref _velocity, _smoothTime);
    }
}
