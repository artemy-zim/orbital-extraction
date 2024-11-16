using UnityEngine;

internal class GemInventory : Inventory 
{
    [SerializeField] private float _collectSpeed;
    [SerializeField] private float _collectAcceleration;

    protected override IFollowStrategy CreateStrategy(ITarget target)
    {
        return new AcceleratingFollower(target, Vector3.zero, _collectSpeed, _collectAcceleration);
    }
}
