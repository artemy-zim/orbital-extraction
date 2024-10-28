using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseWindow : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private PausePanel _pausePanel;

    [SerializeField] private CanvasGroup _canvasGroup;

    public event Action PauseButtonClicked;

    private void Awake()
    {
        Hide();
    }

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(OnButtonClick);
        _pausePanel.ContinueButtonClicked += Hide;
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(OnButtonClick);
        _pausePanel.ContinueButtonClicked += Hide;
    }

    private void OnButtonClick()
    {
        PauseButtonClicked?.Invoke();
        Show();
    }

    private void Hide()
    {
        _canvasGroup.alpha = 0f;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    private void Show()
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
        _pausePanel.OnShow();
    }
}
