using System;
using UnityEngine;

internal class Storage : MonoBehaviour
{
    private int _currentValue;

    public event Action<int> ValueChanged;

    private void Start()
    {
        ValueChanged?.Invoke(_currentValue);
    }

    public void Add()
    {
        _currentValue++;
        ValueChanged?.Invoke(_currentValue);
    }
}
