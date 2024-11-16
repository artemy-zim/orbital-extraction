using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ConveyorAnimator : MonoBehaviour
{
    [SerializeField] private Conveyor _conveyor;
    [SerializeField] private Vector2 _direction;

    private IAnimator _animator;

    private void Awake()
    {
        Material material = TryGetComponent(out MeshRenderer renderer)
            ? renderer.material
            : throw new ArgumentNullException(nameof(renderer));

        renderer.material = new Material(material);
        _animator = new MaterialOffsetMover(renderer.material, _direction, _conveyor.MoveSpeed);
    }

    private void OnEnable()
    {
        _conveyor.Launched += _animator.Play;
        _conveyor.Stopped += _animator.Stop;
    }

    private void OnDisable()
    {
        _conveyor.Launched += _animator.Play;
        _conveyor.Stopped -= _animator.Stop;
    }
}
