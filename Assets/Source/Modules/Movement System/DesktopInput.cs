using UnityEngine;
using UnityEngine.InputSystem;

internal class DesktopInput : BaseInput
{
    private PlayerInput _input;

    protected override void Initialize()
    {
        _input = new PlayerInput();

        _input.Enable();
        _input.Player.Move.performed += OnMove;
        _input.Player.Move.canceled += OnMove;
    }

    protected override void Cleanup()
    {
        _input.Player.Move.performed -= OnMove;
        _input.Player.Move.canceled -= OnMove;

        _input?.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _currentMovable?.SetDirection(context.ReadValue<Vector2>());
    }
}
