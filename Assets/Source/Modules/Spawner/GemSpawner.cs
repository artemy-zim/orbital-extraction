using UnityEngine;

internal class GemSpawner : Spawner<Gem>
{
    [SerializeField] private Gem _prefab;
    [SerializeField] private Transform _container;

    [SerializeField] private float _chance;

    private readonly float _minChance = 0f;
    private readonly float _maxChance = 100f;

    private void OnValidate()
    {
        _chance = Mathf.Clamp(_chance, _minChance, _maxChance);
    }

    protected override bool CanSpawn()
    {
        return Random.Range(_minChance, _maxChance) < _chance;
    }

    protected override Gem GetSpawnable()
    {
        return Instantiate(_prefab, _container);
    }
}
