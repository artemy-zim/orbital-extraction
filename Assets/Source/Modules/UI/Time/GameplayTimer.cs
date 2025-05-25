using UnityEngine;

public class GameplayTimer : Timer
{
    [SerializeField] private RockTotalCounter _rockTotalCounter;
    [SerializeField] private Game _game;

    private readonly int _secondsPerMinute = 60;

    protected override void OnEnable()
    {
        _rockTotalCounter.AllCollected += Reset;
        _game.Started += () => Launch(GameplayTimerData.Instance.SelectedValue.Minutes * _secondsPerMinute);
    }

    protected override void OnDisable()
    {
        _rockTotalCounter.AllCollected -= Reset;    
        _game.Started -= () => Launch(GameplayTimerData.Instance.SelectedValue.Minutes * _secondsPerMinute);
    }
}
