using UnityEngine;

public class GameplayTimer : Timer
{
    [SerializeField] private GameLevel _level;

    protected override void OnEnable()
    {
        _level.Started += Launch;
    }

    protected override void OnDisable()
    {
        _level.Started -= Launch;
    }
}
