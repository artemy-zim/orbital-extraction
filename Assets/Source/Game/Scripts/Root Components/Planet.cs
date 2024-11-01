using UnityEngine;

public class Planet : MonoBehaviour, IAnimatable
{
    public Transform GetTransform()
    {
        return transform;
    }
}
