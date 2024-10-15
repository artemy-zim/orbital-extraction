using TMPro;
using UnityEngine;

public class StorageView : MonoBehaviour
{
    [SerializeField] private Storage _storage;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _storage.ValueChanged += UpdateView;
    }

    private void OnDisable()
    {
        _storage.ValueChanged -= UpdateView;
    }

    private void UpdateView(int value)
    {
        _text.text = value.ToString();
    }
}
