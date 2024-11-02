using System;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _continueButton;

    public event Action Started;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(Pause);
        _continueButton.onClick.AddListener(Resume);
    }

    private void Start()
    {
        Started?.Invoke();
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(Pause);
        _continueButton.onClick.RemoveListener(Resume);
    }

    private void Pause()
    {
        Time.timeScale = 0f;
    }

    private void Resume()
    {
        Time.timeScale = 1f;
    }

    private void OnDestroy()
    {
        Resume();
    }
}
