using System;
using UnityEngine;

internal class InventoryTrigger : TriggerHandler
{
    public event Action<Inventory> Triggered;

    protected override void TryTrigger(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            Triggered?.Invoke(player.Inventory);
        }
    }
}
