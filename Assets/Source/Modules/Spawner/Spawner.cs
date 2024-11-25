using UnityEngine;

internal abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour, ISpawnable
{
    [SerializeField] private TargetTrigger _targetTrigger;

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
            T spawnable = GetSpawnable();

            spawnable.transform.position = position;
            spawnable.OnSpawn();
        }
    }

    protected abstract T GetSpawnable();

    protected abstract bool CanSpawn();
}
