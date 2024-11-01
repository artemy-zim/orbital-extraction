using AYellowpaper;
using UnityEngine;

public class Levitator : MonoBehaviour
{
    [SerializeField] private InterfaceReference<IAnimatable> _animatable;

    [SerializeField] private float _hoverHeight;
    [SerializeField] private float _hoverSpeed;
    [SerializeField] private float _tiltAmount;
    [SerializeField] private float _tiltSpeed;

    private Quaternion _startRotation;
    private Vector3 _startPosition;
    private Transform _transform;

    private void Awake()
    {
        _transform = _animatable.Value.GetTransform();
        _startPosition = _transform.position;
        _startRotation = _transform.rotation;
    }

    private void Update()
    {
        Play();
    }

    private void Play()
    {
        float newPositionY = _startPosition.y + Mathf.Sin(Time.time * _hoverSpeed) * _hoverHeight;
        _transform.position = new Vector3(_startPosition.x, newPositionY, _startPosition.z);

        float tiltAngleX = Mathf.Sin(Time.time * _tiltSpeed) * _tiltAmount;
        float tiltAngleZ = Mathf.Cos(Time.time * _tiltSpeed) * _tiltAmount;

        Quaternion tiltRotation = Quaternion.Euler(tiltAngleX, 0, tiltAngleZ);

        _transform.rotation = _startRotation * tiltRotation;
    }
}