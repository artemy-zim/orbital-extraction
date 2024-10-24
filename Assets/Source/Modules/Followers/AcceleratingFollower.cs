using UnityEngine;

internal class AcceleratingFollower : IFollowStrategy
{
    private float _speed;
    private readonly float _acceleration;

    public AcceleratingFollower(float speed, float acceleration)
    {
        _speed = Mathf.Clamp(speed, 0, float.MaxValue);
        _acceleration = Mathf.Clamp(acceleration, 0, float.MaxValue);
    }

    public void ApplyMovement(Transform transform, Vector3 targetPosition)
    {
        if(transform == null) 
            return;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

        _speed += _acceleration * Time.deltaTime;
    }
}
