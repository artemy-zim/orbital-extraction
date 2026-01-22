using System;
using UnityEngine;

internal class TakeControlTimer : Timer
{
    [SerializeField] private DriverTrigger _trigger;
    [SerializeField] private float _defaultValue;

    public event Action Disabled;
    public event Action Enabled;

    public float DefaultValue => _defaultValue;

    protected override void OnEnable()
    {
        _trigger.EnterTriggered += Enable;
        _trigger.ExitTriggered += Disable;
    }

    protected override void OnDisable()
    {
        _trigger.EnterTriggered -= Enable;
        _trigger.ExitTriggered -= Disable;
    }

    private void Enable()
    {
        Launch(_defaultValue);
        Enabled?.Invoke();
    }

    private void Disable()
    {
        Reset();
        Disabled?.Invoke();
    }
}
