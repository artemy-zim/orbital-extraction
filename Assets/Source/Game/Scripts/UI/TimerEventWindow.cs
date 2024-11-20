using AYellowpaper;
using UnityEngine;

public class TimerEventWindow : MonoBehaviour
{
    [SerializeField] private InterfaceReference<IAnimator> _animator;

    [SerializeField] private Window _window;
    [SerializeField] private Timer _timer;

    private void Awake()
    {
        _window.Hide();
    }

    private void OnEnable()
    {
        _timer.Completed += OnTimerCompleted;
    }

    private void OnDisable()
    {
        _timer.Completed -= OnTimerCompleted;
    }

    private void OnTimerCompleted()
    {
        _window.Show();
        _animator.Value.Play();
    }
}
