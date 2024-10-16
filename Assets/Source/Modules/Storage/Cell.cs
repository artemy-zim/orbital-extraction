using UnityEngine;

public class Cell : MonoBehaviour, ITarget
{
    private ICollectable _collectable;

    public ICollectable Collectable => _collectable;

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void Put(ICollectable collectable)
    {
        _collectable = collectable;
    }
}
