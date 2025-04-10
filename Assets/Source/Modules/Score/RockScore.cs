using UnityEngine;

internal class RockScore : ScoreCounter
{
    [SerializeField] private RockInventory _inventory;

    protected override Inventory GetInventory()
    {
        return _inventory;
    }
}
