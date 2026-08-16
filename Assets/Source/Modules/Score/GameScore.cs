using System;
using System.Collections.Generic;
using UnityEngine;

internal class GameScore : MonoBehaviour
{
    [SerializeField] private List<ScoreCounter> _scores;

    public Action<int> Calculated;

    public int Calculate()
    {
        int counter = 0;

        foreach (var score in _scores) 
        {
            counter += score.Calculate();
        }

        Calculated?.Invoke(counter);

        return counter;
    }
}
