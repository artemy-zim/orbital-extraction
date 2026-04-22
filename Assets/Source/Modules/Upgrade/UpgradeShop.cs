using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YG;

namespace Assets.Source.Modules.Upgrade
{
    internal abstract class UpgradeShop : MonoBehaviour
    {
        [SerializeField] private List<InventoryUpgrade> _upgrades;

        public IReadOnlyList<InventoryUpgrade> Upgrades => _upgrades;

        public event Action OnBought;
        public event Action OnEquipped;

        private void Start()
        {
            InitEquipped();
        }

        public void TryBuy(InventoryUpgrade upgrade)
        {
            if (IsBought(upgrade))
                return;

            if (YandexGame.savesData.gems < upgrade.Cost)
                return;

            YandexGame.savesData.gems -= upgrade.Cost;
            AddBoughtId(upgrade.Id);
            YandexGame.SaveProgress();

            OnBought?.Invoke();
        }

        public void Equip(InventoryUpgrade upgrade)
        {
            if (IsBought(upgrade) == false)
                return;

            if (IsEquipped(upgrade))
                return;

            SetEquippedId(upgrade.Id);
            SetEquippedOnData(upgrade);
            YandexGame.SaveProgress();

            OnEquipped?.Invoke();
        }

        public bool IsBought(InventoryUpgrade upgrade)
        {
            return GetBoughtIds().Contains(upgrade.Id);
        }

        public bool IsEquipped(InventoryUpgrade upgrade)
        {
            return GetEquippedId() == upgrade.Id;
        }

        private void InitEquipped()
        {
            int equippedId = GetEquippedId();
            InventoryUpgrade equipped = _upgrades.FirstOrDefault(u => u.Id == equippedId);

            if (equipped != null)
                SetEquippedOnData(equipped);
        }

        protected abstract List<int> GetBoughtIds();
        protected abstract int GetEquippedId();
        protected abstract void SetEquippedId(int id);
        protected abstract void AddBoughtId(int id);
        protected abstract void SetEquippedOnData(InventoryUpgrade upgrade);

        public abstract float GetSecondaryStat(InventoryUpgrade upgrade);
        public abstract string GetSecondaryStatLabel();
    }
}
