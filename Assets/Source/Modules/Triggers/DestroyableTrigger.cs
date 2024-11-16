using System;
using UnityEngine;

public class DestroyableTrigger : TriggerHandler
{
    public event Action<IDestroyable> Triggered;

    protected override void TryTrigger(Collider other)
    {
        if(other.TryGetComponent(out IDestroyable destroyable))
        {
            Triggered?.Invoke(destroyable);
        }
    }
}
