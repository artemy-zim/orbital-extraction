
using UnityEngine;

internal class TakeControlTimer : Timer
{
    [SerializeField] private ZoneChecker _zoneChecker;

    protected override void OnEnable()
    {
        _zoneChecker.DriverEntered += Launch;
        _zoneChecker.DriverExit += Reset;
    }

    protected override void OnDisable()
    {
        _zoneChecker.DriverEntered -= Launch;
        _zoneChecker.DriverExit -= Reset;
    }
}
