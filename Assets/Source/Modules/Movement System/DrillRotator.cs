using AYellowpaper;
using UniRx;
using UnityEngine;

public class DrillRotator : MonoBehaviour
{
    [SerializeField] private InterfaceReference<IMoverEvents> _mover;

    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _damping;
    [SerializeField] private float _stopThreshold;

    private Transform _transform;
    private float _speed;

    private readonly CompositeDisposable _disposables = new();

    private void OnValidate()
    {
        _direction.x = Mathf.Clamp(_direction.x, -1, 1);
        _direction.y = Mathf.Clamp(_direction.y, -1, 1);
        _direction.z = Mathf.Clamp(_direction.z, -1, 1);
    }

    private void Awake()
    {
        _transform = transform;
    }

    private void OnEnable()
    {
        _mover.Value.Started += OnStarted;
        _mover.Value.Stopped += OnStopped;
    }

    private void OnDisable()
    {
        _mover.Value.Started -= OnStarted;
        _mover.Value.Stopped -= OnStopped;

        _disposables.Clear();
    }

    private void OnStopped()
    {
        Observable.EveryUpdate()
           .TakeWhile(_ => _speed > _stopThreshold)
           .Subscribe(_ => _speed = Mathf.Lerp(_speed, 0f, _damping * Time.deltaTime))
           .AddTo(_disposables);
    }

    private void OnStarted()
    {
        _speed = _maxSpeed;
        _disposables.Clear();

        Observable.EveryUpdate()
            .TakeWhile(_ => _speed > _stopThreshold)
            .Subscribe(_ => Rotate())
            .AddTo(_disposables);
    }

    private void Rotate()
    {
        _transform.Rotate(_speed * Time.deltaTime * _direction);
    }
}
