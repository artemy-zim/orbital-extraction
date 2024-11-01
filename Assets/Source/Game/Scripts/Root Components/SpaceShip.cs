using UnityEngine;

public class SpaceShip : MonoBehaviour, IAnimatable
{
    public Transform GetTransform()
    {
        return transform;
    }
}
