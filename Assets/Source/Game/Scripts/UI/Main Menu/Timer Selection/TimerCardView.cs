using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class TimerCardView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _amountText;

    private int _minutes;

    private void Awake()
    {
        MessageBroker.Default.Receive<TimerCardSelectedMessage>()
            .Subscribe(message => SetColor(message.Minutes))
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

    public void Show(TimerCard card)
    {
        _icon.color = card.Color;
        _minutes = card.Minutes;
        _amountText.text = card.Minutes.ToString();
    }

    private void SetColor(int minutes)
    {
        if(minutes == _minutes)
        {
            _button.image.color = _button.colors.selectedColor;
        }
        else
        {
            _button.image.color = _button.colors.normalColor;
        }
    }

    private void OnCardClick()
    {
        MessageBroker.Default.Publish(new TimerCardSelectedMessage(_minutes));
    }
}
