using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _angle;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform; 
    }

    private void Update()
    {
        _transform.Rotate(_speed * Time.deltaTime * _angle);
    }
}
