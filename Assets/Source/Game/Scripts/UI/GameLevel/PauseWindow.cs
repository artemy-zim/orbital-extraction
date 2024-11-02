using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class PauseWindow : MonoBehaviour
{
    [SerializeField] private Button _showButton;
    [SerializeField] private Button _hideButton;

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
        _showButton.onClick.AddListener(Show);
        _hideButton.onClick.AddListener(Hide);
    }

    private void OnDisable()
    {
        _showButton.onClick.RemoveListener(Show);
        _hideButton.onClick.RemoveListener(Hide);
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
    }
}
