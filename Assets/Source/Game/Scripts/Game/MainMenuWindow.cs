using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class MainMenuWindow : MonoBehaviour
{
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _startScreenButton;
    [SerializeField] private Button _leaderboardButton;
    [SerializeField] private Button _shopButton;

    [SerializeField] private Button _exitSettingsButton;
    [SerializeField] private Button _exitTimerSelectButton;
    [SerializeField] private Button _exitLeaderboardButton;
    [SerializeField] private Button _exitShopButton;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = TryGetComponent(out CanvasGroup canvasGroup)
            ? canvasGroup
            : throw new ArgumentNullException(nameof(canvasGroup));

        Show();
    }

    private void OnEnable()
    {
        _settingsButton.onClick.AddListener(Hide);
        _startScreenButton.onClick.AddListener(Hide);
        _leaderboardButton.onClick.AddListener(Hide);
        _shopButton.onClick.AddListener(Hide);

        _exitSettingsButton.onClick.AddListener(Show);
        _exitTimerSelectButton.onClick.AddListener(Show);
        _exitLeaderboardButton.onClick.AddListener(Show);
        _exitShopButton.onClick.AddListener(Show);
    }

    private void OnDisable()
    {
        _settingsButton.onClick.RemoveListener(Hide);
        _startScreenButton.onClick.RemoveListener(Hide);
        _leaderboardButton.onClick.RemoveListener(Hide);
        _shopButton.onClick.RemoveListener(Hide);

        _exitSettingsButton.onClick.RemoveListener(Show);
        _exitTimerSelectButton.onClick.RemoveListener(Show);
        _exitLeaderboardButton.onClick.RemoveListener(Show);
        _exitShopButton.onClick.RemoveListener(Show);
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
