using UnityEngine;

public class TimerEventWindow : MonoBehaviour
{
    [SerializeField] private Window _window;
    [SerializeField] private Timer _timer;

    private void OnEnable()
    {
        _timer.Completed += _window.Show;
    }

    private void OnDisable()
    {
        _timer.Completed -= _window.Show;
    }
}
