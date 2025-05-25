using System.Collections.ObjectModel;
using System.Linq;
using UniRx;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    [SerializeField] private CellPositionRandomizer _cellShuffler;
    [SerializeField] private Cell _prefab;
    [SerializeField] private int _capacity;

    private readonly Collection<Cell> _cells = new();

    private readonly ReactiveProperty<int> _currentAmountProperty = new();

    public int Capacity => _capacity;
    public IReadOnlyReactiveProperty<int> CurrentAmount => _currentAmountProperty;

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
        if (_currentAmountProperty.Value >= _capacity)
            return;

        Cell cell = _cells.First(cell => cell.IsEmpty);

        collectable.OnCollectFollow(cell.transform, CreateStrategy(cell));
        cell.Put(collectable);

        _currentAmountProperty.Value++;
    }

    public bool TryTakeOutCollectibles(out Collection<ICollectable> collectibles)
    {
        collectibles = _cells
            .Where(cell => cell.IsEmpty == false)
            .Select(cell => cell.TakeOut())
            .ToReactiveCollection();

        if(collectibles.Count > 0)
        {
            _currentAmountProperty.Value = 0;

            return true;
        }

        return false;
    }

    protected abstract IFollowStrategy CreateStrategy(ITarget target);
}
