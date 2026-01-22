using UnityEngine;

internal class RockScore : ScoreCounter
{
    [SerializeField] private RockStorage _storage;

    protected override Storage GetStorage()
    {
        return _storage;
    }
}
