internal class RockTrigger : CollectableTrigger
{
    protected override bool CanCollect(ICollectable collectable) => collectable is Rock;
}
