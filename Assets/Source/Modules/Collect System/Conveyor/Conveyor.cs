using Mono.Collections.Generic;
using System;
using UniRx;
using UnityEngine;

internal class Conveyor : MonoBehaviour
{
    [SerializeField] private Vector3 _curveAmplitude;
    [SerializeField] private float _laySpeed;
    [SerializeField] private float _speed;
    [SerializeField] private float _processDelay;

    [SerializeField] private Cell _startPoint;
    [SerializeField] private Cell _endPoint;

    [SerializeField] private DestroyableTrigger _destroyTrigger;
    [SerializeField] private RockStorage _rockStorage;

    private readonly Collection<IDestroyable> _processingDestroyables = new();
    private bool _isLaunched;

    public float MoveSpeed => _speed;

    public event Action Launched;
    public event Action Stopped;

    private void Awake()
    {
        _isLaunched = false;
    }

    private void OnEnable()
    {
        _destroyTrigger.Triggered += DestroyCollectible;
        _rockStorage.Stored += Launch;
    }

    private void OnDisable()
    {
        _destroyTrigger.Triggered -= DestroyCollectible;
        _rockStorage.Stored -= Launch;
    }

    private void DestroyCollectible(IDestroyable destroyable)
    {
        _processingDestroyables.Remove(destroyable);
        destroyable.Destroy();
        Stop();
    }

    private void Stop()
    {
        if(_processingDestroyables.Count == 0)
        {
            Stopped?.Invoke();
            _isLaunched = false;
        }
    }

    private void Launch()
    {
        if (_isLaunched == false)
        {
            Launched?.Invoke();

            Observable.Interval(TimeSpan.FromSeconds(_processDelay))
                .TakeWhile(_ => TryProcessNextCollectible())
                .Subscribe()
                .AddTo(this);

            _isLaunched = true;
        }
    }

    private bool TryProcessNextCollectible()
    {
        if (_rockStorage.TryTakeOutCollectible(out ICollectable collectible))
        {
            IDestroyable destroyable = collectible as IDestroyable;

            destroyable.OnDestroyFollow(CreateStrategy());
            _processingDestroyables.Add(destroyable);

            return true;
        }

        return false;
    }

    private IFollowStrategy CreateStrategy()
    {
        return new CurveFollower(_startPoint, Vector3.zero, _laySpeed, _curveAmplitude,
            new LinearFollower(_endPoint, Vector3.zero, _speed));
    }
}
