using AYellowpaper;
using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class VehicleAnimator : MonoBehaviour
{
    [SerializeField] private InterfaceReference<IMoverEvents, VehicleMover> _moverEvents;

    private Animator _vehicleAnimator;
    private IMoverEvents _mover;

    private Action _onStarted;
    private Action _onStopped;

    private void Awake()
    {
        _vehicleAnimator = TryGetComponent(out Animator animator) 
            ? animator 
            : throw new ArgumentNullException(nameof(animator));

        _mover = _moverEvents.Value;

        _onStarted = () => SetSpeed(SpeedValues.MovingSpeed);
        _onStopped = () => SetSpeed(SpeedValues.StoppedSpeed);
    }

    private void OnEnable()
    {
        _mover.Started += _onStarted;
        _mover.Stopped += _onStopped;
        _mover.Rotated += SetAngle;
    }

    private void OnDisable()
    {
        _mover.Started -= _onStarted;
        _mover.Stopped -= _onStopped;
        _mover.Rotated -= SetAngle;
    }

    private void SetSpeed(float speed)
    {
        _vehicleAnimator.SetFloat(PlayerVehicleAnimatorData.Params.Speed, speed);
    }

    private void SetAngle(float angle)
    {
        _vehicleAnimator.SetFloat(PlayerVehicleAnimatorData.Params.Angle, angle);
    }

    private static class SpeedValues
    {
        public const float StoppedSpeed = 0f;
        public const float MovingSpeed = 1f;
    }
}
