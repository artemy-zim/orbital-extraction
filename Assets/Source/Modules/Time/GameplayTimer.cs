using UnityEngine;

public class GameplayTimer : Timer
{
    [SerializeField] private GameLevel _level;

    private readonly int _secondsPerMinute = 60;

    private void Awake()
    {
        Init(GameplayTimerData.Instance.SelectedMinutes * _secondsPerMinute);
    }

    protected override void OnEnable()
    {
        _level.Started += Launch;
    }

    protected override void OnDisable()
    {
        _level.Started -= Launch;
    }
}
