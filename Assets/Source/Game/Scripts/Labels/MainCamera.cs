using UnityEngine;

public class MainCamera : MonoBehaviour 
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] float _smoothTime;

    private IFollower _follower;

    public void Init(ICameraTarget target)
    {
        _follower = new SmoothFollower(transform, target, _offset, _smoothTime);
        transform.LookAt(target.GetPosition());
    }

    private void LateUpdate()
    {
        _follower.Follow();
    }

    public void SetTarget(ICameraTarget target) 
    {
        _follower.SetTarget(target);
    }
}
