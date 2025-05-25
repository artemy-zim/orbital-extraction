using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class CardPanel<T> : MonoBehaviour 
{
    [SerializeField] private Button _acceptButton;

    private void Awake()
    {
        _acceptButton.interactable = false;

        MessageBroker.Default.Receive<CardSelectedMessage<T>>()
            .Subscribe(_ => OnCardSelected())
            .AddTo(this);
    }

    private void OnCardSelected()
    {
        _acceptButton.interactable = true;
    }
}
