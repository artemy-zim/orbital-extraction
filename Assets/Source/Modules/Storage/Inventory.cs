using System;
using UnityEngine;

internal class Inventory : MonoBehaviour
{
    [SerializeField] private int _capacity;

    private int _currentValue;

    public int Capacity => _capacity;

    public event Action<int> ValueChanged;

    private void OnValidate()
    {
        _capacity = Mathf.Clamp(_capacity, 0, int.MaxValue);
    }

    private void Start()
    {
        ValueChanged?.Invoke(_currentValue);
    }

    public void Add()
    {
        if(_currentValue < _capacity)
        {
            _currentValue++;
            ValueChanged?.Invoke(_currentValue);
        }
    }

    public void Clear()
    {
        _currentValue = 0;
        ValueChanged?.Invoke(_currentValue);
    }
}
