using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UniRx;
using UnityEngine;

internal abstract class Storage : MonoBehaviour
{
    [SerializeField] private CellCluster _prefab;
    [SerializeField] private CellPositionRandomizer _cellShuffler;
    [SerializeField] private Vector3 _clusterOffset;

    [SerializeField] private InventoryTrigger _trigger;

    private readonly Collection<CellCluster> _clusters = new();
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        CreateCluster(transform.position);
    }

    private void OnEnable()
    {
        _trigger.Triggered += Store;
    }

    private void OnDisable()
    {
        _trigger.Triggered -= Store;
    }

    public void Store(Inventory inventory)
    {
        if (inventory == null)
            return;

        if (inventory.TryTakeOutCollectibles(out Collection<ICollectable> collectibles))
        {
            ProcessCollectibles(collectibles, Add);
        }
    }

    public bool TryTakeOutCollectible(out ICollectable collectible)
    {
        CellCluster cluster = _clusters.LastOrDefault(cluster => cluster.HasFilledCell);

        if (cluster != null)
        {
            collectible = cluster.GetLastFilledCell().TakeOut();
        }
        else
        {
            collectible = null;
        }

        return collectible != null;
    }

    private CellCluster CreateCluster(Vector3 position)
    {
        CellCluster cluster = Instantiate(_prefab, position, transform.rotation, _transform);

        cluster.Init(_cellShuffler);
        _clusters.Add(cluster);

        return cluster;
    }

    private void Add(ICollectable collectible)
    {
        CellCluster cluster = _clusters.FirstOrDefault(cluster => cluster.HasEmptyCell)
            ?? CreateCluster(_clusters.Last().transform.position + _clusterOffset);

        Cell cell = cluster.GetNextEmptyCell();

        collectible.OnCollectFollow(cell.transform, CreateStrategy(cell));
        cell.Put(collectible);
    }

    protected abstract void ProcessCollectibles(IReadOnlyCollection<ICollectable> collectibles, Action<ICollectable> Add);
    protected abstract IFollowStrategy CreateStrategy(ITarget target);
}
