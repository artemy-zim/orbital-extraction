using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
internal abstract class CollectTrigger : MonoBehaviour
{
    private Collider _collectZone;

    public event Action<ICollectable> Triggered;

    private void Awake()
    {
        _collectZone = TryGetComponent(out Collider collider)
            ? collider 
            : throw new ArgumentNullException(nameof(collider));

        _collectZone.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ICollectable collectable))
        {
            if (CanCollect(collectable))
            {
                Triggered?.Invoke(collectable);
            }
        }
    }

    public void Activate()
    {
        if (gameObject.activeSelf)
            return;

        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    protected abstract bool CanCollect(ICollectable collectable);
}
