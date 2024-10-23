using System;
using System.Collections.ObjectModel;
using UnityEngine;

public class CollectiblesDistributor : MonoBehaviour
{
    [SerializeField] private RockStorage _rockStorage;
    [SerializeField] private GemStorage _gemStorage;

    [SerializeField] private InventoryTrigger _inventoryTrigger;

    private void OnEnable()
    {
        _inventoryTrigger.Triggered += Distribute;
    }

    private void OnDisable()
    {
        _inventoryTrigger.Triggered -= Distribute;
    }

    private void Distribute(Inventory inventory)
    {
        Collection<ICollectable> collectibles = inventory.TakeOutCollectibles();
        Storage storage;

        if(inventory is RockInventory)
        {
            storage = _rockStorage;
        }
        else if(inventory is GemInventory)
        {
            storage = _gemStorage;
        }
        else
        {
            throw new InvalidOperationException(nameof(Distribute));
        }

        storage.Store(collectibles);
    }
}
