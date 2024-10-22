
using UnityEngine;

internal class TakeControlTimer : Timer
{
    [SerializeField] private DriverTrigger _trigger;

    protected override void OnEnable()
    {
        _trigger.EnterTriggered += Launch;
        _trigger.ExitTriggered += Reset;
    }

    protected override void OnDisable()
    {
        _trigger.EnterTriggered -= Launch;
        _trigger.ExitTriggered -= Reset;
    }
}
