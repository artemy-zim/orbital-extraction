using UnityEngine;

public interface IFollowStrategy
{
    public void Follow(Transform transform, UpdateMode mode);
    public void Stop();
}
