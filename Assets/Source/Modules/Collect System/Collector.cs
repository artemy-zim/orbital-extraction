using AYellowpaper;
using UnityEngine;

internal class Collector : MonoBehaviour
{
    [SerializeField] private InterfaceReference<ITarget> _target;
    [SerializeField] private CollectTrigger _trigger;

    [SerializeField] private Inventory _inventory;
    [SerializeField] private Storage _storage;

    private void OnEnable()
    {
        _inventory.ValueChanged += OnValueChanged;
        _trigger.Triggered += OnTriggered;
    }

    private void OnDisable()
    {
        _inventory.ValueChanged -= OnValueChanged;
        _trigger.Triggered -= OnTriggered;
    }

    private void OnTriggered(ICollectable collectable)
    {
        collectable.OnCollect(_target.Value);
        _inventory.Add();
        _storage.Add();
        
    }

    private void OnValueChanged(int value)
    {
        if(value <= 0)
        {
            _trigger.Activate();
        }
        else if(value >= _inventory.Capacity) 
        {
            _trigger.Deactivate();
        }
    }
}
