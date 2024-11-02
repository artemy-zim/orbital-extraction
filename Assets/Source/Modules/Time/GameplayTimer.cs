using UnityEngine;

public class GameplayTimer : Timer
{
    [SerializeField] private Game _game;

    private readonly int _secondsPerMinute = 60;

    private void Awake()
    {
        Init(GameplayTimerData.Instance.SelectedMinutes * _secondsPerMinute);
    }

    protected override void OnEnable()
    {
        _game.Started += Launch;
    }

    protected override void OnDisable()
    {
        _game.Started -= Launch;
    }
}
