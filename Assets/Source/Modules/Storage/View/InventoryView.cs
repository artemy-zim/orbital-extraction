using UnityEngine;

internal class InventoryView : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private InventorySlider _slider;

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
        if (value <= 0)
        {
            _slider.Deactivate();
        }
        else if(value > 0) 
        {
            _slider.Activate();
        }

        float fillValue = (float)value / _inventory.Capacity;

        _slider.SetValue(fillValue);
    }
}
