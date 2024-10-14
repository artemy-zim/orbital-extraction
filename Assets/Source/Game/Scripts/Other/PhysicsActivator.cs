using UnityEngine;

[System.Serializable]
public class PhysicsActivator
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _collider;

    public void Activate()
    {
        _collider.enabled = true;
        _rigidbody.isKinematic = false;
    }

    public void Deactivate()
    {
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
    }
}
