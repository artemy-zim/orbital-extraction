using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerCardView : CardView<TimerCard>
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _amountText;

    private TimerCard _card;

    public override void Render(TimerCard card)
    {
        _card = card;
        _icon.color = card.IconColor;
        _amountText.text = card.Minutes.ToString();
    }

    protected override TimerCard GetMessageValue()
    {
        return _card;
    }
}
