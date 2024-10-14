using UnityEngine;

public class RotationLocker : MonoBehaviour
{
    private Quaternion _initialRotation;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _initialRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        _transform.rotation = _initialRotation;
    }
}
