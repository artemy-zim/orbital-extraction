internal class GemCollectTrigger : CollectTrigger
{
    protected override bool CanCollect(ICollectable collectable) => collectable is Gem;
}
