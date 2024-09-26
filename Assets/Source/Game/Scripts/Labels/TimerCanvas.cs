using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCanvas : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _offset;

    private IFollower _follower;

    private void Awake()
    {
        _follower = new LinearFollower(transform, _player, _offset);
    }

    private void Update()
    {
        _follower.Follow();
    }
}
