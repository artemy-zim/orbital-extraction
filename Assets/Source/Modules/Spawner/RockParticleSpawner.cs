using UnityEngine;

internal class RockParticleSpawner : Spawner<RockParticlesPlayer>
{
    [SerializeField] private ObjectPool<RockParticlesPlayer> _pool;

    protected override bool CanSpawn()
    {
        return true;
    }

    protected override RockParticlesPlayer GetSpawnable()
    {
        RockParticlesPlayer particlesPlayer = _pool.GetObject();

        particlesPlayer.Completed += OnCompleted;

        return particlesPlayer;
    }

    private void OnCompleted(RockParticlesPlayer particlesPlayer)
    {
        particlesPlayer.Completed -= OnCompleted;

        _pool.PutObject(particlesPlayer);
    }
}
