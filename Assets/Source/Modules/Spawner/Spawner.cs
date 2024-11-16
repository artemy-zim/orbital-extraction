using UnityEngine;

internal class Spawner<T> : MonoBehaviour where T : MonoBehaviour, ISpawnable
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _container;
    [SerializeField] private float _chance;

    [SerializeField] private TargetTrigger _targetTrigger;

    private readonly float _minChance = 0f;
    private readonly float _maxChance = 100f;

    private void OnValidate()
    {
        _chance = Mathf.Clamp(_chance, _minChance, _maxChance);
    }

    private void OnEnable()
    {
        _targetTrigger.Triggered += Spawn;
    }

    private void OnDisable()
    {
        _targetTrigger.Triggered -= Spawn;
    }

    private void Spawn(ITarget target)
    {
        if (CanSpawn())
        {
            Vector3 position = target.GetPosition();
            T spawnable = Instantiate(_prefab, _container);

            spawnable.transform.position = position;
            spawnable.OnSpawn();
        }
    }

    private bool CanSpawn()
    {
        return Random.Range(_minChance, _maxChance) <= _chance;
    }
}
