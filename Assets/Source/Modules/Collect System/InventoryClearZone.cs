using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class InventoryClearZone : MonoBehaviour
{
    private Collider _clearZone;

    private void Awake()
    {
        _clearZone = TryGetComponent(out Collider collider)
            ? collider
            : throw new ArgumentNullException(nameof(collider));

        _clearZone.isTrigger = true;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IClearable clearable))
        {
            clearable.Clear();
        }
    }*/
}
