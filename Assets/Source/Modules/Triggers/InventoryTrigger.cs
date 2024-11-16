using System;
using UnityEngine;

internal abstract class InventoryTrigger : TriggerHandler
{
    public event Action<Inventory> Triggered;

    protected override void TryTrigger(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (CanTrigger(player.Inventory))
            {
                Triggered?.Invoke(player.Inventory);
            }
        }
    }

    protected abstract bool CanTrigger(Inventory inventory);
}
