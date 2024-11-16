using System;
using UnityEngine;

public class TargetTrigger : TriggerHandler
{
    public event Action<ITarget> Triggered;

    protected override void TryTrigger(Collider other)
    {
        if(other.TryGetComponent(out ITarget target)) 
        {
            Triggered?.Invoke(target);
        }
    }
}
