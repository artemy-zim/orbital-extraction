using System;
using UnityEngine;

[Serializable]
public class PhysicsSwitcher
{
    [SerializeField] private Collider _collider;
    [SerializeField] private Rigidbody _rigidbody;

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
