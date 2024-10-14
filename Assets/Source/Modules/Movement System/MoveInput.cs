using AYellowpaper;
using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

internal class MoveInput : MonoBehaviour
{
    [SerializeField] private InterfaceReference<IMovable, VehicleMover> _vehicle;
    [SerializeField] private InterfaceReference<IMovable, DriverMover> _driver;

    private IMovable _currentMovable;
    private PlayerInput _input;

    private void Awake()
    {
        Initialize();
        Subscribe();
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

    private void Initialize()
    {
        _input = new PlayerInput();

        _input.Enable();
        _input.Player.Move.performed += OnMove;
        _input.Player.Move.canceled += OnMove;
    }

    private void OnDestroy()
    {
        _input.Player.Move.performed -= OnMove;
        _input.Player.Move.canceled -= OnMove;
        _input.Disable();
    }

    private void Set(IMovable movable)
    {
        _currentMovable?.SetDirection(Vector2.zero);

        _currentMovable = movable ??
            throw new ArgumentNullException(nameof(movable));
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        if (_currentMovable == null)
            throw new InvalidOperationException(nameof(_currentMovable));

        _currentMovable.SetDirection(context.ReadValue<Vector2>());
    }
}
