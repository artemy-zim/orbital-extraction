using System;
using UniRx;
using UnityEngine;

internal class MobileInput : BaseInput
{
    [SerializeField] private Joystick _joystick;

    private IDisposable _joystickSubscription;

    protected override void Initialize()
    {
        _joystick.gameObject.SetActive(true);
        _joystick.enabled = true;

        _joystickSubscription = Observable.EveryUpdate()
            .Select(_ => _joystick.Direction)
            .DistinctUntilChanged()
            .Subscribe(OnMove)
            .AddTo(this);
    }

    protected override void Cleanup()
    {
        _joystickSubscription?.Dispose();

        if (_joystick != null)
        {
            _joystick.enabled = false;
            _joystick.gameObject.SetActive(false);
        }
    }

    private void OnMove(Vector2 direction)
    {
        _currentMovable?.SetDirection(direction);
    }
}
