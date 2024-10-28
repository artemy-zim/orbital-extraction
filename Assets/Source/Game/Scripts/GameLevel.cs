using System;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    [SerializeField] private PauseWindow _pauseWindow;
    [SerializeField] private PausePanel _pausePanel;

    public event Action Started;

    private void OnEnable()
    {
        _pauseWindow.PauseButtonClicked += Pause;
        _pausePanel.ContinueButtonClicked += Resume;
    }

    private void OnDisable()
    {
        _pauseWindow.PauseButtonClicked -= Pause;
        _pausePanel.ContinueButtonClicked -= Resume;
    }

    private void Start()
    {
        Started?.Invoke();
    }

    private void Pause()
    {
        Time.timeScale = 0f;
    }

    private void Resume()
    {
        Time.timeScale = 1f;
    }
}
