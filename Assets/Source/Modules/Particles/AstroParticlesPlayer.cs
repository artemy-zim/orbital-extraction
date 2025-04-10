using UnityEngine;

public class AstroParticlesPlayer : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem.Stop();
    }

    public void Play()
    {
        _particleSystem.Emit(_particleSystem.main.maxParticles);
    }
}
