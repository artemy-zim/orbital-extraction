using UnityEngine;
using UnityEngine.UI;

public class InventorySlider : MonoBehaviour
{
    [SerializeField] private Image _fill;

    public float FillAmount => _fill.fillAmount;

    public void SetValue(float value)
    {
        _fill.fillAmount = value;
    }

    public void Activate()
    {
        if (gameObject.activeSelf)
            return;

        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        if (gameObject.activeSelf == false)
            return;

        gameObject.SetActive(false);
    }
}
