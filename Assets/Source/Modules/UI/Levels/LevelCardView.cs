using TMPro;
using UnityEngine;
using YG;

public class LevelCardView : CardView<LevelCard>
{
    [SerializeField] private TextMeshProUGUI _orderText;
    [SerializeField] private TextMeshProUGUI _scoreRecordText;

    private LevelCard _card;

    public override void Render(LevelCard card)
    {
        _card = card;
        _orderText.text = card.Order.ToString();
        _scoreRecordText.text = YandexGame.savesData.levelScores[card.Order - 1].ToString();
        Debug.Log($"Rendered level card with order: {_card.Order}");
        Debug.Log($"Rendered its saved score: {YandexGame.savesData.levelScores[card.Order - 1]}");
    }

    protected override LevelCard GetMessageValue() => _card;
}
