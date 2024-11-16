using UnityEngine;
internal class RockInventoryTrigger : InventoryTrigger
{
    protected override bool CanTrigger(Inventory inventory) => inventory is RockInventory; 
}
