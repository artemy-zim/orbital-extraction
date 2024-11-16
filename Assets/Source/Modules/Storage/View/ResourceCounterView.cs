using TMPro;
using UniRx;
using UnityEngine;

public class ResourceCounterView : MonoBehaviour
{
    [SerializeField] private ResourceCounter _counter;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _counter.Amount
            .Subscribe(value => UpdateView(value))
            .AddTo(this);
    }

    private void UpdateView(int value)
    {
        _text.text = value.ToString();
    }
}
