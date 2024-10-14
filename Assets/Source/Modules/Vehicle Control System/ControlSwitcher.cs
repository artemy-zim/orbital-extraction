using UnityEngine;
using UniRx;

public class ControlSwitcher : MonoBehaviour
{
    [SerializeField] private TakeControlTimer _timer;
    [SerializeField] private VehicleControlScreen _screen;

    private void OnEnable()
    {
        _screen.ExitButtonClicked += SetDriver;
        _timer.Completed += SetVehicle;
    }

    private void Start()
    {
        SetDriver();
    }

    private void OnDisable()
    {
        _screen.ExitButtonClicked -= SetDriver;
        _timer.Completed -= SetVehicle;
    }

    private void SetVehicle()
    {
        MessageBroker.Default.Publish(new VehicleControlMessage());
    }

    private void SetDriver()
    {
        MessageBroker.Default.Publish(new DriverControlMessage());
    }
}
