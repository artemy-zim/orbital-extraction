using UnityEngine;

internal class LinearFollower : Follower
{
    private float _speed;

    public LinearFollower(Transform transform, ITarget target, Vector3 offset, float speed) : base(transform, target, offset) 
    {
        _speed = Mathf.Clamp(speed, 0, float.MaxValue);
    }

    protected override void TakeStep(Transform transform, Vector3 newPosition)
    {
        if (transform == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, newPosition, _speed * Time.deltaTime);
    }
}
