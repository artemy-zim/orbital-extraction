using TMPro;
using UniRx;
using UnityEngine;

internal class GameScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameScore _score;

    private void Awake()
    {
        _score.Score
            .Subscribe(value => UpdateView(value))
            .AddTo(this);
    }

    private void UpdateView(int value)
    {
        _text.text = value.ToString();
    }
}
