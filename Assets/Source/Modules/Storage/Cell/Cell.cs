using UnityEngine;

public class Cell : MonoBehaviour, ITarget
{
    private ICollectable _collectable;

    public bool IsEmpty => _collectable == null;

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void Put(ICollectable collectable)
    {
        _collectable ??= collectable;
    }

    public ICollectable TakeOut()
    {
        ICollectable collectable = _collectable;
        _collectable = null;

        return collectable;
    }
}
