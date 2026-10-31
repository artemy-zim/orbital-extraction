using AYellowpaper;
using UnityEngine;

public class DirectionalLooker : MonoBehaviour
{
    [SerializeField] private InterfaceReference<ITransformable> _animatable;
    [SerializeField] private GameObject _target;

    private Transform _transform;

    private void Awake()
    {
        _transform = _animatable.Value.GetTransform();
    }

    private void Update()
    {
        _transform.LookAt(_target.transform, Vector3.up);
    }
}