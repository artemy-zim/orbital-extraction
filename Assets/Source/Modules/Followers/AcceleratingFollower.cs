using UnityEngine;

internal class AcceleratingFollower : Follower
{
    private float _speed;
    private readonly float _acceleration;

    public AcceleratingFollower(Transform transform, ITarget target, Vector3 offset, float speed, float acceleration) : base(transform, target, offset)
    {
        _speed = Mathf.Clamp(speed, 0, float.MaxValue);
        _acceleration = Mathf.Clamp(acceleration, 0, float.MaxValue);
    }

    protected override void TakeStep(Transform transform, Vector3 newPosition)
    {
        if (transform == null)
            return;

        _speed += _acceleration * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, newPosition, _speed * Time.deltaTime);
    }
}
