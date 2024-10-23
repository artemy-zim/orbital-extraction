using System;
using System.Collections.ObjectModel;
using System.Linq;
using UniRx;
using UnityEngine;

internal abstract class Storage : MonoBehaviour
{
    [SerializeField] private CellCluster _prefab;
    [SerializeField] private CellPositionRandomizer _cellShuffler;
    [SerializeField] private Vector3 _clusterOffset;

    private readonly Collection<CellCluster> _clusters = new();
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        CreateCluster(transform.position);
    }

    public void Store(Collection<ICollectable> collectibles)
    {
        if (collectibles.Count == 0 || collectibles == null) 
            return;

        ProcessCollectibles(collectibles, Add);
    }

    private CellCluster CreateCluster(Vector3 position)
    {
        CellCluster cluster = Instantiate(_prefab, position, Quaternion.identity, _transform);

        cluster.Init(_cellShuffler);
        _clusters.Add(cluster);
        return cluster;
    }

    private void Add(ICollectable collectible)
    {
        CellCluster cluster = _clusters.Last();

        if (cluster.TryGetNextCell(out Cell cell) == false)
        {
            cluster = CreateCluster(cluster.transform.position + _clusterOffset);
            cluster.TryGetNextCell(out cell);
        }

        collectible.OnCollect(cell);
        cell.Put(collectible);
    }

    protected abstract void ProcessCollectibles(Collection<ICollectable> collectibles, Action<ICollectable> add);
}
