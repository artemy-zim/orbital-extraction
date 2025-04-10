using AYellowpaper;
using System;
using UniRx;
using UnityEngine;

internal abstract class BaseInput : MonoBehaviour
{
    [SerializeField] private InterfaceReference<IMovable, VehicleMover> _vehicle;
    [SerializeField] private InterfaceReference<IMovable, DriverMover> _driver;

    protected IMovable _currentMovable;

    private void OnEnable()
    {
        Subscribe();
        Initialize();
    }

    private void OnDisable()
    {
        Cleanup();
    }

    private void Subscribe()
    {
        MessageBroker.Default.Receive<VehicleControlMessage>()
            .Subscribe(_ => Set(_vehicle.Value))
            .AddTo(this);

        MessageBroker.Default.Receive<DriverControlMessage>()
            .Subscribe(_ => Set(_driver.Value))
            .AddTo(this);
    }

    private void Set(IMovable movable)
    {
        _currentMovable?.SetDirection(Vector2.zero);
        _currentMovable = movable ?? throw new ArgumentNullException(nameof(movable));
    }

    protected abstract void Initialize();
    protected abstract void Cleanup();
}
