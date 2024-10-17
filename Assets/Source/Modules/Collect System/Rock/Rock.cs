using UnityEngine;

public class Rock : Resource
{
    protected override void Follow(ITarget target, Transform transform)
    {
        IFollower follower = new LinearFollower(transform, target, Vector3.zero);

        follower.Follow();

        transform.rotation = Random.rotation;
    }
}
