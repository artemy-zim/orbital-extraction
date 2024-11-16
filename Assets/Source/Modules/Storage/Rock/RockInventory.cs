using UnityEngine;

internal class RockInventory : Inventory 
{
    [SerializeField] private float _collectSpeed;

    protected override IFollowStrategy CreateStrategy(ITarget target)
    {
        return new LinearFollower(target, Vector3.zero, _collectSpeed);
    } 
}
