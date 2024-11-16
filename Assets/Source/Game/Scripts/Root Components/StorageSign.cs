using UnityEngine;

public class StorageSign : MonoBehaviour, ITransformable
{
    public Transform GetTransform()
    {
        return transform;
    }
}
