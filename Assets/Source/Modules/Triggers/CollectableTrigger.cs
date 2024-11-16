using System;
using UnityEngine;
using UnityEngine.Events;

internal abstract class CollectableTrigger : TriggerHandler
{
    [SerializeField] private UnityEvent _onTriggered;

    public event Action<ICollectable> Triggered;

    protected override void TryTrigger(Collider other)
    {
        if (other.TryGetComponent(out ICollectable collectable))
        {
            if (CanCollect(collectable))
            {
                Triggered?.Invoke(collectable);
                _onTriggered?.Invoke();
            }
        }
    }

    public void Activate()
    {
        if (gameObject.activeSelf)
            return;

        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    protected abstract bool CanCollect(ICollectable collectable);
}
