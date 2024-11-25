using System.Collections.Generic;
using UnityEngine;

internal class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _container;

    private Queue<T> _pool;

    private void Awake()
    {
        _pool = new();
    }

    public T GetObject()
    {
        T obj;

        if (_pool.Count == 0)
        {
            obj = Instantiate(_prefab);
            obj.transform.parent = _container;

            return obj;
        }

        obj = _pool.Dequeue();
        obj.gameObject.SetActive(true);

        return obj;
    }

    public void PutObject(T obj)
    {
        _pool.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }
}
