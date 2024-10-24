using System;
using System.Collections.ObjectModel;
using System.Linq;
using UniRx;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    [SerializeField] private CellPositionRandomizer _cellShuffler;
    [SerializeField] private Cell _prefab;
    [SerializeField] private int _capacity;

    private readonly ReactiveCollection<Cell> _cells = new();

    public int Capacity => _capacity;
    public IReadOnlyReactiveProperty<int> ObservableValue => _cells
        .ObserveEveryValueChanged(_ => _cells.Count(cell => !cell.IsEmpty))
        .ToReactiveProperty();

    public event Action ResourceAdded;

    private void Awake()
    {
        for (int i = 0; i < _capacity; i++)
        {
            Cell cell = Instantiate(_prefab, transform, false);

            _cellShuffler.Shuffle(transform.position, cell);
            _cells.Add(cell);
        }
    }

    public void Add(ICollectable collectable)
    {
        if (ObservableValue.Value >= Capacity)
            return;

        Cell cell = _cells.First(cell => cell.IsEmpty);

        collectable.OnCollect(cell, CreatePolicy());
        cell.Put(collectable);

        ResourceAdded?.Invoke();
    }

    public Collection<ICollectable> TakeOutCollectibles()
    {
        Collection<ICollectable> collectibles = _cells
            .Where(cell => cell.IsEmpty == false)
            .Select(cell => cell.TakeOut())
            .ToReactiveCollection();

        return collectibles;
    }

    protected abstract IFollowStrategy CreatePolicy();
}
