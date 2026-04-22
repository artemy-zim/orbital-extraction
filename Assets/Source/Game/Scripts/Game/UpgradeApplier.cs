using Assets.Source.Modules.Upgrade;
using UnityEngine;

internal class UpgradeApplier : MonoBehaviour
{
    [Header("Astronaut Bag")]
    [SerializeField] private GemInventory _gemInventory;
    [SerializeField] private Collider _gatherCollider;
    [SerializeField] private MeshFilter _bagMeshFilter;
    [SerializeField] private MeshRenderer _bagMeshRenderer;

    [Header("Drill")]
    [SerializeField] private RockInventory _rockInventory;
    [SerializeField] private VehicleMover _vehicleMover;
    [SerializeField] private MeshFilter _drillMeshFilter;
    [SerializeField] private MeshRenderer _drillMeshRenderer;

    private void Awake()
    {
        if (EquippedUpgradeData.Instance == null)
            return;

        ApplyBagUpgrade(EquippedUpgradeData.Instance.EquippedBag);
        ApplyDrillUpgrade(EquippedUpgradeData.Instance.EquippedDrill);
    }

    private void ApplyBagUpgrade(InventoryUpgrade upgrade)
    {
        if (upgrade == null)
            return;

        _gemInventory.SetCapacity(upgrade.Capacity);

        if (_gatherCollider is SphereCollider sphere)
            sphere.radius = upgrade.GatherRadius;

        if (upgrade.Mesh != null && _bagMeshFilter != null)
            _bagMeshFilter.mesh = upgrade.Mesh;

        if (upgrade.Material != null && _bagMeshRenderer != null)
            _bagMeshRenderer.material = upgrade.Material;
    }

    private void ApplyDrillUpgrade(InventoryUpgrade upgrade)
    {
        if (upgrade == null)
            return;

        _rockInventory.SetCapacity(upgrade.Capacity);
        _vehicleMover.SetMovementSpeed(upgrade.Speed);

        if (upgrade.Mesh != null && _drillMeshFilter != null)
            _drillMeshFilter.mesh = upgrade.Mesh;

        if (upgrade.Material != null && _drillMeshRenderer != null)
            _drillMeshRenderer.material = upgrade.Material;
    }
}
