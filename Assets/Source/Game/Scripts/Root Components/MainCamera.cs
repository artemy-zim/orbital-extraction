using AYellowpaper;
using UniRx;
using UnityEngine;

public class MainCamera : MonoBehaviour 
{
    [SerializeField] private InterfaceReference<ITarget, Vehicle> _vehicle;
    [SerializeField] private InterfaceReference<ITarget, Driver> _driver;

    [SerializeField] private Vector3 _offset;
    [SerializeField] float _smoothTime;

    private IFollower _follower;

    private void Awake()
    {
        Initialize(_driver.Value);
        Subscribe();
    }

    private void Initialize(ITarget target)
    {
        _follower = new SmoothFollower(transform, target, _offset, _smoothTime);
        transform.LookAt(target.GetPosition());
    }

    private void Subscribe()
    {
        MessageBroker.Default.Receive<VehicleControlMessage>()
            .Subscribe(_ => SetTarget(_vehicle.Value))
            .AddTo(this);

        MessageBroker.Default.Receive<DriverControlMessage>()
            .Subscribe(_ => SetTarget(_driver.Value))
            .AddTo(this);
    }

    private void LateUpdate()
    {
        _follower.Follow();
    }

    private void SetTarget(ITarget target) 
    {
        _follower.SetTarget(target);
    }
}
