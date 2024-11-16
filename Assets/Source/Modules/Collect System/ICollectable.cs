using UnityEngine;

public interface ICollectable 
{
    public void OnCollectFollow(Transform parentTransform, IFollowStrategy followPolicy);
}
