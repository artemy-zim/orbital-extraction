using UnityEngine;

internal class LinearFollower : BaseFollower
{
    private readonly float _speed;

    public LinearFollower(ITarget target, Vector3 offset, float speed, IFollowStrategy innerFollower = null) 
        : base(target, offset, innerFollower)
    {
        _speed = Mathf.Clamp(speed, 0, float.MaxValue);
    }

    protected override void Move(Transform transform, Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}
