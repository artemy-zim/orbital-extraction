using UnityEngine;

internal class RockScore : ResourceScore
{
    [SerializeField] private RockCounter _counter;

    protected override ResourceCounter GetCounter()
    {
        return _counter;
    }
}
