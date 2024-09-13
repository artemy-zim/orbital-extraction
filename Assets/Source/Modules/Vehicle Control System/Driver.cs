using UnityEngine;

[RequireComponent (typeof(IMovable))]
[RequireComponent(typeof(Collider))]
internal class Driver : MonoBehaviour, ICameraTarget
{
    private Collider _collider;
    private IMovable _movable;

    public IMovable Movable => _movable;

    private void Awake()
    {
        _movable = GetComponent<IMovable>();
        _collider = GetComponent<Collider>();
    }

    public void Activate()
    {
        _collider.enabled = true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        _collider.enabled = false;
        gameObject.SetActive(false);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
