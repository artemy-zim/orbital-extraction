using UnityEngine;

internal class Collector : MonoBehaviour
{
    [SerializeField] private CollectableTrigger _trigger;

    [SerializeField] private Inventory _inventory;
    [SerializeField] private Storage _storage;

    private void OnEnable()
    {
        _inventory.ValueChanged += HandleInventoryChange;
        _trigger.Triggered += OnTriggered;
    }

    private void OnDisable()
    {
        _inventory.ValueChanged -= HandleInventoryChange;
        _trigger.Triggered -= OnTriggered;
    }

    private void OnTriggered(ICollectable collectable)
    {
        _inventory.Add(collectable);
        _storage.Add();
    }

    private void HandleInventoryChange(int value)
    {
        if(value >= _inventory.Capacity)
        {
            _trigger.Deactivate();
        }
        else if(value == 0)
        {
            _trigger.Activate();
        }
    }
}
