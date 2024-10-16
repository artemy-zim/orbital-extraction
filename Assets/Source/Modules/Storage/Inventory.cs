using System;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private CellShuffler _cellShuffler;
    [SerializeField] private Cell _prefab;
    [SerializeField] private int _capacity;

    private readonly Collection<Cell> _cells = new();

    public int Capacity => _capacity;
    private int CurrentAmount => _cells.Count(cell => cell.Collectable != null);

    public event Action<int> ValueChanged;

    private void Awake()
    {
        for (int i = 0; i < _capacity; i++)
        {
            Cell cell = Instantiate(_prefab, transform, false);

            _cells.Add(cell);
        }

        _cellShuffler.Shuffle(transform.position, _cells);
    }

    public void Add(ICollectable collectable)
    {
        if (CurrentAmount >= Capacity)
            return;

        Cell cell = _cells.First(cell => cell.Collectable == null);

        cell.Put(collectable);
        collectable.OnCollect(cell);

        ValueChanged?.Invoke(CurrentAmount);
    }
}
