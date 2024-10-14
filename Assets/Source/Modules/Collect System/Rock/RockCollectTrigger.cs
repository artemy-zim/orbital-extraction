internal class RockCollectTrigger : CollectTrigger
{
    protected override bool CanCollect(ICollectable collectable) => collectable is Rock;
}
