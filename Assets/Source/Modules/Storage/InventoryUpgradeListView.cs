using Assets.Source.Modules.Upgrade;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUpgradeListView : MonoBehaviour
{
    [SerializeField] private InventoryUpgradeView _prefab;
    [SerializeField] private UpgradeShop _shop;

    private readonly List<InventoryUpgradeView> _views = new();

    private void OnEnable()
    {
        if (_views.Count == 0)
            Show();

        Subscribe();
        RefreshStates();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        foreach (InventoryUpgradeView view in _views)
        {
            view.OnBuyClicked += OnBuy;
            view.OnEquipClicked += OnEquip;
        }

        _shop.OnBought += RefreshStates;
        _shop.OnEquipped += RefreshStates;
    }

    private void Unsubscribe()
    {
        foreach (InventoryUpgradeView view in _views)
        {
            view.OnBuyClicked -= OnBuy;
            view.OnEquipClicked -= OnEquip;
        }

        _shop.OnBought -= RefreshStates;
        _shop.OnEquipped -= RefreshStates;
    }

    private void Show()
    {
        foreach (InventoryUpgrade upgrade in _shop.Upgrades)
        {
            InventoryUpgradeView view = Instantiate(_prefab, transform);
            view.Show(upgrade, _shop.GetSecondaryStat(upgrade), _shop.GetSecondaryStatLabel());
            _views.Add(view);
        }
    }

    private void RefreshStates()
    {
        for (int i = 0; i < _views.Count; i++)
        {
            InventoryUpgrade upgrade = _shop.Upgrades[i];
            _views[i].UpdateState(_shop.IsBought(upgrade), _shop.IsEquipped(upgrade));
        }
    }

    private void OnBuy(InventoryUpgrade upgrade)
    {
        _shop.TryBuy(upgrade);
    }

    private void OnEquip(InventoryUpgrade upgrade)
    {
        _shop.Equip(upgrade);
    }
}
