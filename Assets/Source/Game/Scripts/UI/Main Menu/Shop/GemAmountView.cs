using TMPro;
using UniRx;
using UnityEngine;

public class GemAmountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GemAmount _gemAmount;

    private void Awake()
    {
        _gemAmount.AmountProperty
            .Subscribe(value => UpdateView(value))
            .AddTo(this);
    }

    private void UpdateView(int value)
    {
        _text.text = value.ToString();
    }
}
