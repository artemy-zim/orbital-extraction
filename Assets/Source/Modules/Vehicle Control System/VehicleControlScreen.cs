using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

internal class VehicleControlScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _exitButton;

    public event Action ExitButtonClicked;

    private void Awake()
    {
        Hide();

        MessageBroker.Default.Receive<VehicleControlMessage>()
            .Subscribe(_ => Show())
            .AddTo(this);

        MessageBroker.Default.Receive<DriverControlMessage>()
            .Subscribe(_ => Hide())
            .AddTo(this);
    }

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(OnButtonClick);
    }

    private void Show()
    {
        _canvasGroup.alpha = 1f;
        _exitButton.interactable = true;
    }

    private void Hide()
    {
        _canvasGroup.alpha = 0f;
        _exitButton.interactable = false;
    }

    private void OnButtonClick()
    {
        ExitButtonClicked?.Invoke();
    }
}
