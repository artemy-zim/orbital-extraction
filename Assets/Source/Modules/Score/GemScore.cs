using UnityEngine;

internal class GemScore : ScoreCounter
{
    [SerializeField] private GemStorage _storage;

    protected override Storage GetStorage()
    {
        return _storage;
    }
}
