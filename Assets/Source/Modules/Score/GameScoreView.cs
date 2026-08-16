using TMPro;
using UniRx;
using UnityEngine;

internal class GameScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameScore _score;

    private void OnEnable()
    {
        _score.Calculated += UpdateView;
    }

    private void OnDisable()
    {
        _score.Calculated -= UpdateView;
    }

    private void UpdateView(int value)
    {
        _text.text = value.ToString();
    }
}
