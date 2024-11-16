using UnityEngine;

internal class AcceleratingFollower : BaseFollower
{
    private readonly float _acceleration;
    private float _speed;

    public AcceleratingFollower(ITarget target, Vector3 offset, float speed, float acceleration, IFollowStrategy innerFollower = null) 
        : base(target, offset, innerFollower)
    {
        _speed = Mathf.Clamp(speed, 0, float.MaxValue);
        _acceleration = Mathf.Clamp(acceleration, 0, float.MaxValue);
    }

    protected override void Move(Transform transform, Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

        _speed += _acceleration * Time.deltaTime;
    }
}
