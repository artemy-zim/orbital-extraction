using System.Collections.Generic;
using YG;

namespace Assets.Source.Modules.Upgrade
{
    internal class DrillShop : UpgradeShop
    {
        protected override List<int> GetBoughtIds() => YandexGame.savesData.boughtDrillIds;
        protected override int GetEquippedId() => YandexGame.savesData.equippedDrillId;
        protected override void SetEquippedId(int id) => YandexGame.savesData.equippedDrillId = id;
        protected override void AddBoughtId(int id) => YandexGame.savesData.boughtDrillIds.Add(id);
        protected override void SetEquippedOnData(InventoryUpgrade upgrade) =>
            EquippedUpgradeData.Instance.SetEquippedDrill(upgrade);

        public override float GetSecondaryStat(InventoryUpgrade upgrade) => upgrade.Speed;
        public override string GetSecondaryStatLabel() => "Speed";
    }
}
