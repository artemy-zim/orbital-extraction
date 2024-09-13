using UnityEngine;

internal class SmoothFollower : MonoBehaviour, IFollower
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothTime;

    private ICameraTarget _target;
    private Transform _transform;
    private Vector3 _velocity = Vector3.zero;

    private void Awake()
    {
        _transform = transform;

        _transform.position = GetTargetPosition();
        _transform.LookAt(_target.GetPosition());
    }

    private void LateUpdate()
    {
        Follow();
    }

    public void SetTarget(ICameraTarget target)
    {
        _target = target;
    }

    private Vector3 GetTargetPosition()
    {
        return _target.GetPosition() + _offset;
    }

    private void Follow()
    {
        if (_target == null)
            return;

        Vector3 targetPosition = GetTargetPosition();

        _transform.position = Vector3.SmoothDamp(_transform.position, targetPosition, ref _velocity, _smoothTime);
    }
}
