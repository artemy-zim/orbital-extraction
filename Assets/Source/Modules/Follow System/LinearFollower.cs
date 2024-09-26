using UnityEngine;

internal class LinearFollower : Follower
{
    public LinearFollower(Transform transform, ICameraTarget target, Vector3 offset) : base(transform, target, offset) { }

    protected override void TakeStep(Transform transform, Vector3 newPosition)
    {
        if (transform == null)
            return;

        transform.position = newPosition;
    }
}
