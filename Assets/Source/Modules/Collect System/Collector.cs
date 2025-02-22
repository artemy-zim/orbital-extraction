using UniRx;
using UnityEngine;

internal class Collector : MonoBehaviour
{
    [SerializeField] private CollectableTrigger _trigger;
    [SerializeField] private Inventory _inventory;

    private void Awake()
    {
        _inventory.CurrentAmount
            .Subscribe(value => HandleInventoryChange(value))
            .AddTo(this);
    }

    private void OnEnable()
    {
        _trigger.Triggered += OnTriggered;
    }

    private void OnDisable()
    {
        _trigger.Triggered -= OnTriggered;
    }

    private void OnTriggered(ICollectable collectable)
    {
        _inventory.Add(collectable);
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
