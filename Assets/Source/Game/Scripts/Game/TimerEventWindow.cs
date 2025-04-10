using AYellowpaper;
using UnityEngine;

public class TimerEventWindow : MonoBehaviour
{
    [SerializeField] private GameplayTimer _timer;
    [SerializeField] private RockTotalCounter _rockTotalCounter;

    [SerializeField] private InterfaceReference<IAnimator> _animator;
    [SerializeField] private Window _window;

    private void Awake()
    {
        _window.Hide();
    }

    private void OnEnable()
    {
        _rockTotalCounter.AllCollected += ShowEndWindow;
        _timer.Completed += ShowEndWindow;
    }

    private void OnDisable()
    {
        _rockTotalCounter.AllCollected -= ShowEndWindow;
        _timer.Completed -= ShowEndWindow;
    }

    private void ShowEndWindow()
    {
        _window.Show();
        _animator.Value.Play();
    }
}
