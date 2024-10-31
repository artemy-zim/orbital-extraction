using System;
using UnityEngine;

public class PhysicsSwitcher
{
    private readonly Collider _collider;
    private readonly Rigidbody _rigidbody;

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
        _collider.enabled = true;
        _rigidbody.isKinematic = false;
    }

    public void DisablePhysics()
    {
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
    }
}
