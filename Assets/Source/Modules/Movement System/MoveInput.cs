using System;
using UnityEngine;
using UnityEngine.InputSystem;

internal class MoveInput : MonoBehaviour, IControl
{
    private PlayerInput _input;
    private IMovable _movable;

    public void Initialize(IMovable movable, PlayerInput input)
    {
        _input = input ?? throw new ArgumentNullException(nameof(input));
        Set(movable);

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

    public void Set(IMovable movable)
    {
        _movable?.SetDirection(Vector2.zero);

        _movable = movable ?? throw new ArgumentNullException(nameof(movable));
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        if (_movable == null)
            throw new InvalidOperationException(nameof(_movable));

        _movable.SetDirection(context.ReadValue<Vector2>());
    }
}
