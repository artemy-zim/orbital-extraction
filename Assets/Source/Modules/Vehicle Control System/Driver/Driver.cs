using System;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(Collider))]
internal class Driver : Player
{
    [SerializeField] private Vehicle _vehicle;

    private Collider _collider;

    private void Awake()
    {
        _collider = TryGetComponent(out Collider collider)
            ? collider
            : throw new ArgumentNullException(nameof(collider));

        Subscribe();
    }

    private void Subscribe()
    {
        MessageBroker.Default.Receive<VehicleControlMessage>()
            .Subscribe(_ => Deactivate())
            .AddTo(this);

        MessageBroker.Default.Receive<DriverControlMessage>()
            .Subscribe(_ => Activate())
            .AddTo(this);
    }

    private void Activate()
    {
        transform.position = _vehicle.GetExitPosition(_collider);
        _collider.enabled = true;
        gameObject.SetActive(true);
    }

    private void Deactivate()
    {
        _collider.enabled = false;
        gameObject.SetActive(false);
    }
}
