using UniRx;
using UnityEngine;

internal class ResourceCounter : MonoBehaviour
{
    private readonly ReactiveProperty<int> _currentValue = new();

    public IReadOnlyReactiveProperty<int> CurrentValue => _currentValue;

    private void Awake()
    {
        _currentValue.Value = 0;
    }

    public void Add()
    {
        _currentValue.Value++;
    }
}
