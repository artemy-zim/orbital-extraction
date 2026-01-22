using TMPro;
using UniRx;
using UnityEngine;

public class ResourceCounterView : MonoBehaviour
{
    [SerializeField] private Storage _storage;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _storage.FilledCellsCount
            .Subscribe(value => UpdateView(value))
            .AddTo(this);
    }

    private void UpdateView(int value)
    {
        _text.text = value.ToString();
    }
}
