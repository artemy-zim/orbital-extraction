using UnityEngine;

internal class SmoothFollower : BaseFollower
{
    private readonly float _smoothTime;

    private Vector3 _velocity = Vector3.zero;

    public SmoothFollower(ITarget target, Vector3 offset, float smoothTime, IFollowStrategy innerFollower = null)
        : base(target, offset, innerFollower)
    {
        _smoothTime = Mathf.Clamp(smoothTime, 0, float.MaxValue);
    }

    protected override void Move(Transform transform, Vector3 targetPosition)
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
    }
}
