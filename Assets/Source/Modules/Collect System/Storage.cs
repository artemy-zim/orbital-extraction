using System;
using UnityEngine;

internal class Storage : MonoBehaviour
{
    [SerializeField] private int _capacity;

    private int _currentValue;

    public int CurrentValue => _currentValue;

    public event Action Changed;

    public void OnValidate()
    {
        _capacity = Mathf.Clamp(_capacity, 0, int.MaxValue);
    }

    public void Add()
    {
        if(_currentValue < _capacity)
        {
            _currentValue++;
            Changed?.Invoke();
        }
    }

    public void Remove()
    {
        if(_currentValue > 0)
        {
            _currentValue--;
            Changed?.Invoke();
        }
    }
}
