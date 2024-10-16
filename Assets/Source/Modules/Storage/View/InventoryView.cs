using UnityEngine;

internal class InventoryView : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private InventorySlider _slider;

    private void Awake()
    {
        _slider.Deactivate();
    }

    private void OnEnable()
    {
        _inventory.ValueChanged += UpdateView;
    }

    private void OnDisable()
    {
        _inventory.ValueChanged -= UpdateView;
    }

    private void UpdateView(int value)
    {
        float fillValue = (float)value / _inventory.Capacity;

        _slider.SetValue(fillValue);

        if (value > 0)
        {
            _slider.Activate();
        }
        else
        {
            _slider.Deactivate();
        }
    }
}
