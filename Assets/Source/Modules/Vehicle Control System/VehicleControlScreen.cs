using System;
using UnityEngine;
using UnityEngine.UI;

internal class VehicleControlScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _exitButton;

    public event Action ExitButtonClicked;

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Show()
    {
        _canvasGroup.alpha = 1f;
        _exitButton.interactable = true;
    }

    public void Hide()
    {
        _canvasGroup.alpha = 0f;
        _exitButton.interactable = false;
    }

    private void OnButtonClick()
    {
        ExitButtonClicked?.Invoke();
    }
}
