using System;
using UnityEngine;

[Serializable]
public class PhysicsSwitcher
{
    [SerializeField] private Collider _collider;
    [SerializeField] private Rigidbody _rigidbody;

    private bool _isDisabled;

    public PhysicsSwitcher(Collider collider, Rigidbody rigidbody)
    {
        _collider = collider != null 
            ? collider 
            : throw new ArgumentNullException(nameof(collider));

        _rigidbody = rigidbody != null 
            ? rigidbody 
            : throw new ArgumentNullException(nameof(rigidbody));
    }

    public void EnablePhysics() 
    {
        if (_isDisabled == false)
            return;

        _collider.enabled = true;
        _rigidbody.isKinematic = false;
        _isDisabled = false;
    }

    public void DisablePhysics()
    {
        if (_isDisabled)
            return;

        _collider.enabled = false;
        _rigidbody.isKinematic = true;
        _isDisabled = true; 
    }
}
