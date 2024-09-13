using UnityEngine;

internal class Mover : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;

    private Transform _transform;
    private Vector3 _direction;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
       Rotate();
        Move();
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = new Vector3(direction.x, _direction.y, direction.y);
    }

    private void Rotate()
    {
        if (_direction == Vector3.zero)
            return;

        Quaternion targetRotation = Quaternion.LookRotation(_direction, Vector3.up);

        _transform.rotation = targetRotation;
    }

    private void Move()
    {
        _transform.Translate(_speed * Time.deltaTime * _direction, Space.World);
    }
}
