using UnityEngine;

internal class GemScore : ResourceScore
{
    [SerializeField] private GemCounter _counter;

    protected override ResourceCounter GetCounter()
    {
        return _counter;
    }
}
