using System;
using UnityEngine;

public class InputCompositeRoot : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private MoveInput _controller;

    private PlayerInput _playerInput;
    private IMovable _movable;

    private void Awake()
    {
        Initialize();

        _controller.Initialize(_movable, _playerInput);
    }

    private void Initialize()
    {
        if (_player.TryGetComponent(out IMovable movable))
        {
            _movable = movable;
        }
        else
        {
            throw new ArgumentNullException(nameof(movable));
        }

        _playerInput = new PlayerInput();
    }
}
