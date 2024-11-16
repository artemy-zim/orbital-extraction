using UnityEngine;

public class Rock : Resource, ITarget
{
    public Vector3 GetPosition()
    {
        return Transform.position;
    }
}