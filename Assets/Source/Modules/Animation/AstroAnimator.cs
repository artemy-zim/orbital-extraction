using AYellowpaper;
using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AstroAnimator : MonoBehaviour
{
    [SerializeField] private InterfaceReference<IMoverEvents, DriverMover> _moverEvents;

    private Animator _astroAnimator;
    private IMoverEvents _mover;

    private void Awake()
    {
        _astroAnimator = TryGetComponent(out Animator animator) 
            ? animator 
            : throw new ArgumentNullException(nameof(animator));

        _mover = _moverEvents.Value;
    }

    private void OnEnable()
    {
        _mover.Started += OnStarted;
        _mover.Stopped += OnStopped;
    }

    private void OnDisable()
    {
        _mover.Started -= OnStarted;
        _mover.Stopped -= OnStopped;
    }

    private void OnStarted()
    {
        _astroAnimator.SetBool(PlayerAstroAnimatorData.Params.IsRunning, true);
    }

    private void OnStopped()
    {
        _astroAnimator.SetBool(PlayerAstroAnimatorData.Params.IsRunning, false);
    }
}
