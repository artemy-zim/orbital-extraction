using UnityEngine;

internal class Collector : MonoBehaviour, ITarget
{
    [SerializeField] private CollectTrigger _trigger;
    [SerializeField] private Storage _storage;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void OnEnable()
    {
        _storage.ValueChanged += OnValueChanged;
        _trigger.Triggered += OnTriggered;
    }

    private void OnDisable()
    {
        _storage.ValueChanged -= OnValueChanged;
        _trigger.Triggered -= OnTriggered;
    }

    public Vector3 GetPosition()
    {
        return _transform.position;
    }

    private void OnTriggered(ICollectable collectable)
    {
        collectable.OnCollect(this);
        _storage.Add();
    }

    private void OnValueChanged(int value)
    {
        if(value <= 0)
        {
            _trigger.Activate();
        }
        else if(value >= _storage.Capacity) 
        {
            _trigger.Deactivate();
        }
    }
}
