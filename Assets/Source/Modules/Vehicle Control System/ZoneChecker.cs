using System;
using UnityEngine;

internal class ZoneChecker : MonoBehaviour
{
    [SerializeField] private SphereCollider _collider;

    private float _radius;

    public Vector3 Center => _collider.transform.TransformPoint(_collider.center);
    public float Radius => _radius;

    public event Action DriverEntered;
    public event Action DriverExit;

    private void Awake()
    {
        _collider.isTrigger = true;

        _radius = _collider.radius * Mathf.Max(_collider.transform.localScale.x, _collider.transform.localScale.y, _collider.transform.localScale.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Driver _))
        {
            DriverEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Driver _))
        {
            DriverExit?.Invoke();
        }
    }
}
