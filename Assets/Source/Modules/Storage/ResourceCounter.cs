using UniRx;
using UnityEngine;

internal class ResourceCounter : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;

    private readonly ReactiveProperty<int> _currentValue = new();

    public IReadOnlyReactiveProperty<int> CurrentValue => _currentValue;

    private void Awake()
    {
        _currentValue.Value = _inventory.ObservableValue.Value;
    }

    private void OnEnable()
    {
        _inventory.ResourceAdded += Add;
    }

    private void OnDisable()
    {
        _inventory.ResourceAdded -= Add;
    }

    public void Add()
    {
        _currentValue.Value++;
    }
}
