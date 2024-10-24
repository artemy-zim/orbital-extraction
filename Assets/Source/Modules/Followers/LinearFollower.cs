using UnityEngine;

internal class LinearFollower : IFollowStrategy
{
    private readonly float _speed;

    public LinearFollower(float speed)
    {
        _speed = Mathf.Clamp(speed, 0, float.MaxValue);
    }

    public void ApplyMovement(Transform transform, Vector3 targetPosition)
    {
        if (transform == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }

}
