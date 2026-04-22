using UnityEngine;

namespace Assets.Source.Modules.Upgrade
{
    public class EquippedUpgradeData : MonoBehaviour
    {
        public static EquippedUpgradeData Instance { get; private set; }

        public InventoryUpgrade EquippedBag { get; private set; }
        public InventoryUpgrade EquippedDrill { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void SetEquippedBag(InventoryUpgrade upgrade)
        {
            EquippedBag = upgrade;
        }

        public void SetEquippedDrill(InventoryUpgrade upgrade)
        {
            EquippedDrill = upgrade;
        }
    }
}
