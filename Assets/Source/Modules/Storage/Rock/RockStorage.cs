using System;
using System.Collections.ObjectModel;

internal class RockStorage : Storage
{
    protected override void ProcessCollectibles(Collection<ICollectable> collectibles, Action<ICollectable> add)
    {
        foreach (var collectable in collectibles)
        {
            add(collectable);
        }
    }
}
