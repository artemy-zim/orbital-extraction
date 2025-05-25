using System.Collections.Generic;
using UniRx;
using UnityEngine;

internal class GameScore : MonoBehaviour
{
    [SerializeField] private GameplayTimer _timer;

    [SerializeField] private List<ScoreCounter> _scores;

    private readonly ReactiveProperty<int> _score = new();
    public IReadOnlyReactiveProperty<int> Score => _score;

    private void OnEnable()
    {
        _timer.Completed += Calculate;
    }

    private void OnDisable()
    {
        _timer.Completed -= Calculate;
    }

    private void Calculate()
    {
        int counter = 0;

        foreach (var score in _scores) 
        {
            counter += score.Calculate();
        }

        _score.Value = counter;
    }
}
