using UnityEngine;

public class Gem : Resource, ISpawnable
{
    [SerializeField] private ImpulseApplier _impulseApplier;
    [SerializeField] private Rigidbody _rigidbody;

    public void OnSpawn()
    {
        _impulseApplier.GiveImpulse(_rigidbody);
    }
}