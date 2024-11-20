using System.Collections.Generic;
using UnityEngine;

public class InventoryUpgradeListView : MonoBehaviour
{
    [SerializeField] private InventoryUpgradeView _prefab;
    [SerializeField] private List<InventoryUpgrade> _upgrades;

    private void Awake()
    {
        Show(_upgrades);
    }

    private void Show(IEnumerable<InventoryUpgrade> upgrades)
    {
        foreach (InventoryUpgrade upgrade in upgrades)
        {
            InventoryUpgradeView inventoryUpgrade = Instantiate(_prefab, transform);
            inventoryUpgrade.Show(upgrade);
        }
    }
}
