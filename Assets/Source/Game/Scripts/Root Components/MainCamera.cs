using AYellowpaper;
using UniRx;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private InterfaceReference<ITarget, Vehicle> _vehicle;
    [SerializeField] private InterfaceReference<ITarget, Driver> _driver;
    [SerializeField] private InterfaceReference<IMoverEvents, VehicleMover> _vehicleMover;
    [SerializeField] private InterfaceReference<IMoverEvents, DriverMover> _driverMover;

    [SerializeField] private Vector3 _offset;
    [SerializeField] float _smoothTime;

    private IFollowStrategy _vehicleFollower;
    private IFollowStrategy _driverFollower;
    private IFollowStrategy _currentFollower;

    private void Awake()
    {
        Initialize();
        Subscribe();

        Focus(_driverFollower);
        transform.LookAt(_driver.Value.GetPosition());
    }

    private void OnEnable()
    {
        _vehicleMover.UnderlyingValue.Started += () => Focus(_vehicleFollower);
        _driverMover.UnderlyingValue.Started += () => Focus(_driverFollower);
    }

    private void OnDisable()
    {
        _vehicleMover.UnderlyingValue.Started -= () => Focus(_vehicleFollower);
        _driverMover.UnderlyingValue.Started -= () => Focus(_driverFollower);
    }

    private void Initialize()
    {
        _vehicleFollower = new SmoothFollower(_vehicle.Value, _offset, _smoothTime);
        _driverFollower = new SmoothFollower(_driver.Value, _offset, _smoothTime);
    }

    private void Subscribe()
    {
        MessageBroker.Default.Receive<VehicleControlMessage>()
            .Subscribe(_ => Focus(_vehicleFollower))
            .AddTo(this);

        MessageBroker.Default.Receive<DriverControlMessage>()
            .Subscribe(_ => Focus(_driverFollower))
            .AddTo(this);
    }

    private void Focus(IFollowStrategy targetFollower)
    {
        _currentFollower?.Stop();
        _currentFollower = targetFollower;
        _currentFollower.Follow(transform, UpdateMode.EveryLateUpdate);
    }

    private void OnDestroy()
    {
        _currentFollower?.Stop();
    }
}
