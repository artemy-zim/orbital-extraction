using UnityEngine;

public class Planet : MonoBehaviour, ITransformable
{
    public Transform GetTransform()
    {
        return transform;
    }
}
