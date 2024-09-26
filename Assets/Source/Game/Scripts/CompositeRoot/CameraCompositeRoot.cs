using System;
using UnityEngine;

public class CameraCompositeRoot : MonoBehaviour
{
    [SerializeField] private MainCamera _camera;
    [SerializeField] private Player _player;

    private void Awake()
    {
        if(_player.TryGetComponent(out ICameraTarget target))
        {
            _camera.Init(target);
        }
        else
        {
            throw new ArgumentNullException(nameof(target));
        }
    }
}
