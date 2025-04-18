using TMPro;
using UniRx;
using UnityEngine;

public class ResourceCounterView : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _inventory.CurrentAmount
            .Subscribe(value => UpdateView(value))
            .AddTo(this);
    }

    private void UpdateView(int value)
    {
        _text.text = value.ToString();
    }
}
