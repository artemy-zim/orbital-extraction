using UnityEngine;

internal class GemScore : ScoreCounter
{
    [SerializeField] private GemInventory _inventory;

    protected override Inventory GetInventory()
    {
        return _inventory;
    }
}
