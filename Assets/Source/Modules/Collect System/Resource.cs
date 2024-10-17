using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public abstract class Resource : MonoBehaviour, ICollectable
{
    private Collider _collider;
    private Rigidbody _rigidbody;
    private Transform _transform;

    private void Awake()
    {
        _collider = TryGetComponent(out Collider collider) 
            ? collider
            : throw new ArgumentNullException(nameof(collider));

        _rigidbody = TryGetComponent(out Rigidbody rigidbody)
            ? rigidbody
            : throw new ArgumentNullException(nameof(rigidbody));

        _transform = transform;
    }

    public void OnCollect(Cell cell)
    {
        if (cell == null)
            return;

        _transform.SetParent(cell.transform);

        _collider.enabled = false;
        _rigidbody.isKinematic = true;

        Follow(cell, _transform);
    }

    protected abstract void Follow(ITarget target, Transform transform);
}
