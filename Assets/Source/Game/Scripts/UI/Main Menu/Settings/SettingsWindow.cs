using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class SettingsWindow : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _settingsButton;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = TryGetComponent(out CanvasGroup canvasGroup)
            ? canvasGroup
            : throw new ArgumentNullException(nameof(canvasGroup));

        Hide();
    }

    private void OnEnable()
    {
        _settingsButton.onClick.AddListener(Show);
        _exitButton.onClick.AddListener(Hide);
    }

    private void OnDisable()
    {
        _settingsButton.onClick.RemoveListener(Show);
        _exitButton.onClick.RemoveListener(Hide);
    }

    private void Show()
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    private void Hide()
    {
        _canvasGroup.alpha = 0f;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
}
