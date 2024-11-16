using UnityEngine;
using Random = UnityEngine.Random;

public class Resource : MonoBehaviour, ICollectable, IDestroyable
{
    [SerializeField] private PhysicsSwitcher _physicsSwitcher;

    private IFollowStrategy _currentFollower;

    protected Transform Transform { get; private set; }

    private void Awake()
    {
        Transform = transform;
    }

    public void OnCollectFollow(Transform parentTransform, IFollowStrategy followStrategy)
    {
        if (parentTransform == null || followStrategy == null)
            return;

        _physicsSwitcher.DisablePhysics();
        Transform.SetParent(parentTransform);
        Transform.rotation = Random.rotation;

        Follow(followStrategy);
    }

    public void OnDestroyFollow(IFollowStrategy followStrategy)
    {
        if (followStrategy == null)
            return;

        _physicsSwitcher.EnablePhysics();
        Follow(followStrategy);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void Follow(IFollowStrategy followStrategy)
    {
        _currentFollower?.Stop();
        _currentFollower = followStrategy;
        followStrategy.Follow(Transform, UpdateMode.EveryUpdate);
    }

    private void OnDestroy()
    {
        _currentFollower?.Stop();
    }
}
