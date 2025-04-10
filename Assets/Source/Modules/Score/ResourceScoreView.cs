using TMPro;
using UniRx;
using UnityEngine;

internal class ResourceScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private ScoreCounter _score;

    private void Awake()
    {
        _score.Expression
            .Subscribe(data => UpdateView(data))
            .AddTo(this);
    }

    private void UpdateView(ScoreExpressionData data)
    {
        if (data is null)
            return;

        _text.text = $"{data.ResourceCount} x {data.Multiplier} = {data.Total}";
    }
}
