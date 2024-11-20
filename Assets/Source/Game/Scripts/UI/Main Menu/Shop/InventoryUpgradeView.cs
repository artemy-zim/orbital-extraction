using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUpgradeView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private TextMeshProUGUI _capacityText;
    [SerializeField] private Image _image;

    public void Show(InventoryUpgrade upgrade)
    {
        _costText.text = upgrade.Cost.ToString();
        _capacityText.text = upgrade.Capacity.ToString();
        _image.sprite = upgrade.Sprite;
    }
}
