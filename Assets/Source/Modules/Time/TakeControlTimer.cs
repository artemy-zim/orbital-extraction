using UnityEngine;

internal class TakeControlTimer : Timer
{
    [SerializeField] private DriverTrigger _trigger;
    [SerializeField] private float _defaultValue;

    public float DefaultValue => _defaultValue;

    private void Awake()
    {
        Init(_defaultValue);
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
