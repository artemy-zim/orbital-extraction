using UnityEngine;

[RequireComponent(typeof(IMovable))]
internal class Vehicle : MonoBehaviour, ICameraTarget
{
    [SerializeField] private Transform _exitPoint;

    private IMovable _movable;

    public IMovable Movable => _movable;
    public Vector3 ExitPosition => _exitPoint.position;

    private void Awake()
    {
        _movable = GetComponent<IMovable>();
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
