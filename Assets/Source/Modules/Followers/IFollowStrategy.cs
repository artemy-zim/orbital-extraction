using UnityEngine;

public interface IFollowStrategy
{
    public void ApplyMovement(Transform transform, Vector3 targetPosition);
}
