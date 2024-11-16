internal class GemTrigger : CollectableTrigger
{
    protected override bool CanCollect(ICollectable collectable) => collectable is Gem;
}
