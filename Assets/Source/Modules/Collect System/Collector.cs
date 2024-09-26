using System;
using UnityEngine;

[RequireComponent (typeof(Collider))]
internal abstract class Collector : MonoBehaviour 
{
    private Collider _collectZone;

    public event Action<ICollectable> Collected;

    private void Awake()
    {
        _collectZone = GetComponent<Collider>();
        _collectZone.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ICollectable collectable))
        {
            if (CanCollect(collectable))
            {
                Collected?.Invoke(collectable);
            }
        }
    }

    protected abstract bool CanCollect(ICollectable collectable);
}
