using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class ImpulseApplier
{
    [SerializeField] private float _minForce;
    [SerializeField] private float _maxForce;
    [SerializeField] private float _radius;
    [SerializeField] private float _upwardsModifier;

    public void GiveImpulse(Rigidbody rigidbody)
    {
        float force = GetForce();
        Vector3 direction = GetDirection();

        rigidbody.AddExplosionForce(force, rigidbody.position - direction, _radius, _upwardsModifier, ForceMode.Impulse);
    }

    private float GetForce()
    {
        return Random.Range(_minForce, _maxForce);
    }

    private Vector3 GetDirection() 
    {
        float minValue = -1f;
        float maxValue = 1f;

        float x = Random.Range(minValue, maxValue);
        float y = Random.Range(minValue, maxValue);
        float z = Random.Range(minValue, maxValue);

        return new Vector3(x, y, z);
    }
}
