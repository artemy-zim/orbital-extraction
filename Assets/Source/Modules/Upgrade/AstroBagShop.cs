using System.Collections.Generic;
using YG;

namespace Assets.Source.Modules.Upgrade
{
    internal class AstroBagShop : UpgradeShop
    {
        protected override List<int> GetBoughtIds() => YandexGame.savesData.boughtAstroBagIds;
        protected override int GetEquippedId() => YandexGame.savesData.equippedAstroInventoryId;
        protected override void SetEquippedId(int id) => YandexGame.savesData.equippedAstroInventoryId = id;
        protected override void AddBoughtId(int id) => YandexGame.savesData.boughtAstroBagIds.Add(id);
        protected override void SetEquippedOnData(InventoryUpgrade upgrade) =>
            EquippedUpgradeData.Instance.SetEquippedBag(upgrade);

        public override float GetSecondaryStat(InventoryUpgrade upgrade) => upgrade.GatherRadius;
        public override string GetSecondaryStatLabel() => "Radius";
    }
}
