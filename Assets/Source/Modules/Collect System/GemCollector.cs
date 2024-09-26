internal class GemCollector : Collector
{
    protected override bool CanCollect(ICollectable collectable) => collectable is Gem;
}
