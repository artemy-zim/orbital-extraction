using System;
using UnityEngine;

public class CameraCompositeRoot : MonoBehaviour
{
    [SerializeField] private MainCamera _camera;
    [SerializeField] private Player _player;

    private ICameraTarget _target;
    private IFollower _follower;

    private void Awake()
    {
        Validate();

        _follower.SetTarget(_target);
    }

    private void Validate()
    {
        try
        {
            Initialize();
        }
        catch (Exception e)
        {
            throw new ArgumentNullException(e.Message, e);
        }
    }

    private void Initialize()
    {
        if(_camera.TryGetComponent(out IFollower follower))
        {
            _follower = follower;
        }
        else
        {
            throw new ArgumentNullException(nameof(follower));
        }

        if(_player.TryGetComponent(out ICameraTarget target))
        {
            _target = target;
        }
        else
        {
            throw new ArgumentNullException(nameof(target));
        }
    }
}
