using UnityEngine;

public class SpaceShip : MonoBehaviour, ITransformable
{
    public Transform GetTransform()
    {
        return transform;
    }
}
