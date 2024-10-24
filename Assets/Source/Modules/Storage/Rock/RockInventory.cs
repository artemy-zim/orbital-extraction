using UnityEngine;

internal class RockInventory : Inventory 
{
    [SerializeField] private float _collectSpeed;

    protected override IFollowStrategy CreatePolicy()
    {
        return new LinearFollower(_collectSpeed);
    }
}
