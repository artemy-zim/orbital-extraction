using System;
using UnityEngine;

public abstract class TriggerHandler : MonoBehaviour
{
    [SerializeField] private Collider _collider;

    private void Awake()
    {
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        TryTrigger(other);
    }

    protected abstract void TryTrigger(Collider other);
}
