internal class GemInventoryTrigger : InventoryTrigger
{
    protected override bool CanTrigger(Inventory inventory) => inventory is GemInventory;
}
