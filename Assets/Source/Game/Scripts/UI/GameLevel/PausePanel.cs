using System;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private PanelAnimator _panelAnimator;

    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitButton;

    public event Action ContinueButtonClicked;
    public event Action ExitButtonClicked;

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(OnContinueButtonClicked);
        _exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void OnDisable()
    {
        _continueButton?.onClick.RemoveListener(OnContinueButtonClicked);
        _exitButton?.onClick.RemoveListener(OnExitButtonClicked);
    }

    public void OnShow()
    {
        _panelAnimator.Play();
    }

    private void OnContinueButtonClicked()
    {
        ContinueButtonClicked?.Invoke();
    }

    private void OnExitButtonClicked()
    {
        ExitButtonClicked?.Invoke();
    }
}
