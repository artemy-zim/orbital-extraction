using System;
using System.Collections.Generic;
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

    private readonly HashSet<IDestroyable> _processingDestroyables = new();
    private IDisposable _processSubscription;

    public float MoveSpeed => _speed;

    public event Action Launched;
    public event Action Stopped;

    private void OnEnable()
    {
        _destroyTrigger.Triggered += DestroyCollectible;
        _rockStorage.OnAdded.AddListener(Launch);
    }

    private void OnDisable()
    {
        _destroyTrigger.Triggered -= DestroyCollectible;
        _rockStorage.OnAdded.AddListener(Launch);
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
        }
    }

    private void Launch()
    {
        if (_processingDestroyables.Count == 0)
        {
            Launched?.Invoke();
        }

        _processSubscription?.Dispose();
        _processSubscription = Observable.Interval(TimeSpan.FromSeconds(_processDelay))
            .TakeWhile(_ => TryProcessNextCollectible()) 
            .Subscribe(_ => { }, () => _processSubscription = null)
            .AddTo(this);
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
