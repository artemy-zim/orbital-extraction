using AYellowpaper;
using System.Collections.Generic;
using UnityEngine;

public class VehicleParticlesPlayer : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> _particleSystems;
    [SerializeField] private InterfaceReference<IMoverEvents, VehicleMover> _vehicleMoverEvents;

    private IMoverEvents _moverEvents;

    private void Awake()
    {
        Stop();

        _moverEvents = _vehicleMoverEvents.Value;
    }

    private void OnEnable()
    {
        _moverEvents.Started += Play;
        _moverEvents.Stopped += Stop;
    }

    private void OnDisable()
    {
        _moverEvents.Started -= Play;
        _moverEvents.Stopped -= Stop;
    }

    private void Play()
    {
        foreach (ParticleSystem particleSystem in _particleSystems)
        {
            particleSystem.Play();
        }
    }

    private void Stop()
    {
        foreach(ParticleSystem particleSystem in _particleSystems)
        {
            particleSystem.Stop();
        }
    }
}
