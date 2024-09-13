using UnityEngine;

public class Player : MonoBehaviour, ICameraTarget
{
    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
