using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryUpgradeView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private TextMeshProUGUI _capacityText;
    [SerializeField] private TextMeshProUGUI _secondaryStatAmount;
    [SerializeField] private TextMeshProUGUI _secondaryStatName;
    [SerializeField] private Image _image;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _equipButton;
    [SerializeField] private GameObject _equippedIndicator;

    private InventoryUpgrade _upgrade;

    public UnityAction<InventoryUpgrade> OnBuyClicked;
    public UnityAction<InventoryUpgrade> OnEquipClicked;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(Buy);
        _equipButton.onClick.AddListener(Equip);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(Buy);
        _equipButton.onClick.RemoveListener(Equip);
    }

    public void Show(InventoryUpgrade upgrade, float secondaryStatAmount, string secondarysStatText)
    {
        _costText.text = upgrade.Cost.ToString();
        _capacityText.text = upgrade.Capacity.ToString();
        _secondaryStatAmount.text = secondaryStatAmount.ToString();
        _secondaryStatName.text = secondarysStatText;
        _image.sprite = upgrade.Sprite;
        _upgrade = upgrade;
    }

    public void UpdateState(bool isBought, bool isEquipped)
    {
        _buyButton.gameObject.SetActive(isBought == false);
        _buyButton.interactable = true;
        _equipButton.gameObject.SetActive(isBought && isEquipped == false);
        _equipButton.interactable = true;
        _equippedIndicator.SetActive(isEquipped);
    }

    private void Buy()
    {
        OnBuyClicked?.Invoke(_upgrade);
    }

    private void Equip()
    {
        OnEquipClicked?.Invoke(_upgrade);
    }
}
