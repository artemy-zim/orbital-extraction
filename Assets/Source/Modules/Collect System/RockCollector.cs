internal class RockCollector : Collector
{
    protected override bool CanCollect(ICollectable collectable) => collectable is Rock;
}
