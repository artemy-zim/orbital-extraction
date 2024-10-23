using UnityEngine;

public class Gem : Resource
{
    [SerializeField] private float _speed;
    [SerializeField] private float _acceleration;

    protected override IFollower CreateFollower(ITarget target, Transform transform)
    {
        return new AcceleratingFollower(transform, target, Vector3.zero, _speed, _acceleration);
    }
}
