using UnityEngine;

internal class GemInventory : Inventory 
{
    [SerializeField] private float _collectSpeed;
    [SerializeField] private float _collectAcceleration;

    protected override IFollowStrategy CreatePolicy()
    {
        return new AcceleratingFollower(_collectSpeed, _collectAcceleration);
    }
}
