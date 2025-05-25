using AYellowpaper;
using UnityEngine;

public class TimerEventWindow : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    [SerializeField] private InterfaceReference<IAnimator> _animator;
    [SerializeField] private Window _window;

    private void Awake()
    {
        _window.Hide();
    }

    private void OnEnable()
    {
        _timer.Completed += ShowEndWindow;
    }

    private void OnDisable()
    {
        _timer.Completed -= ShowEndWindow;
    }

    private void ShowEndWindow()
    {
        _window.Show();
        _animator.Value.Play();
    }
}
