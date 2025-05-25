using UniRx;
using UnityEngine;
using UnityEngine.UI;

public abstract class CardView<T> : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Awake()
    {
        MessageBroker.Default.Receive<CardSelectedMessage<T>>()
            .Subscribe(message => SetColor(message))
            .AddTo(this);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnCardClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnCardClick);
    }

    private void SetColor(CardSelectedMessage<T> message)
    {
        _button.image.color = ReferenceEquals(message.Value, GetMessageValue()) ? _button.colors.selectedColor : _button.colors.normalColor;
    }

    private void OnCardClick()
    {
        MessageBroker.Default.Publish(new CardSelectedMessage<T>(GetMessageValue()));
    }

    public abstract void Render(T card);
    protected abstract T GetMessageValue();
}
