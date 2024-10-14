using UnityEngine;

internal class StorageView : MonoBehaviour
{
    [SerializeField] private Storage _storage;
    [SerializeField] private StorageSlider _slider;

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
        if (value <= 0)
        {
            _slider.Deactivate();
        }
        else if(value > 0) 
        {
            _slider.Activate();
        }

        float fillValue = (float)value / _storage.Capacity;

        _slider.SetValue(fillValue);
    }
}
