using System;
using UnityEngine;
using UnityEngine.Pool;

internal abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour, ISpawnable 
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolSize;
    [SerializeField] private int _poolMaxSize;

    private ObjectPool<T> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (spawnable) => Spawn(spawnable),
            actionOnRelease: (spawnable) => spawnable.OnDespawn(),
            actionOnDestroy: (spawnable) => Destroy(spawnable),
            collectionCheck: true,
            defaultCapacity: _poolSize,
            maxSize: _poolMaxSize
            );
    }

    private void Release()
    {
        throw new NotImplementedException(nameof(Release));
    }

    private void Get()
    {
        _pool.Get();
    }

    protected abstract void Spawn(T prefab);
}
