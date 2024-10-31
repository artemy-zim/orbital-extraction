using UnityEngine;

internal class TakeControlTimer : Timer
{
    [SerializeField] private DriverTrigger _trigger;
    [SerializeField] private float _value;

    private void Awake()
    {
        Init(_value);
    }

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
