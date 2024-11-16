using System;
using UnityEngine;

internal class DriverTrigger : TriggerHandler
{
    public event Action EnterTriggered;
    public event Action ExitTriggered;

    protected override void TryTrigger(Collider other)
    {
        if(other.TryGetComponent(out Driver _))
        {
            EnterTriggered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Driver _))
        {
            ExitTriggered?.Invoke();
        }
    }
}
