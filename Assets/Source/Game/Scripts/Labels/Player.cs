using UnityEngine;

public class Player : MonoBehaviour, ITarget
{
    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
