using UnityEngine;

public class Player : MonoBehaviour, ITarget
{
    [SerializeField] private Inventory _inventory;

    public Inventory Inventory => _inventory;

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
