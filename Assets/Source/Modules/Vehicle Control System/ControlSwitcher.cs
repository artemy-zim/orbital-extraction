using System;
using UnityEngine;

public class ControlSwitcher : MonoBehaviour
{
    [SerializeField] private TakeControlTimer _timer;
    [SerializeField] private VehicleControlScreen _screen;
    [SerializeField] private MainCamera _camera;
    [SerializeField] private MoveInput _moveInput;

    [SerializeField] private Driver _driver;
    [SerializeField] private Vehicle _vehicle;

    private IControl _control;
    private IFollower _follower;

    private void Awake()
    {
        _follower = _camera.TryGetComponent(out IFollower follower) ? follower : throw new ArgumentNullException(nameof(follower));
        _control = _moveInput;

        _screen.Hide();
    }

    private void OnEnable()
    {
        _screen.ExitButtonClicked += SetDriver;
        _timer.Completed += SetVehicle;
    }

    private void OnDisable()
    {
        _screen.ExitButtonClicked -= SetDriver;
        _timer.Completed -= SetVehicle;
    }

    private void SetVehicle()
    {
        _control.Set(_vehicle.Movable);
        _follower.SetTarget(_vehicle);
        _screen.Show();
        _driver.Deactivate();
    }

    private void SetDriver()
    {
        _control.Set(_driver.Movable);
        _follower.SetTarget(_driver);
        _screen.Hide();
        _driver.transform.position = _vehicle.ExitPosition;
        _driver.Activate();
    }
}
