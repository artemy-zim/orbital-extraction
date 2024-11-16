using UniRx;
using UnityEngine;

internal class ResourceCounter : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;

    private readonly ReactiveProperty<int> _amount = new();

    public IReadOnlyReactiveProperty<int> Amount => _amount;

    private void Awake()
    {
        _inventory.ResourceAddedObservable
            .Subscribe(_ => Add())
            .AddTo(this);
    }

    private void Add()
    {
        _amount.Value++;
    }
}
