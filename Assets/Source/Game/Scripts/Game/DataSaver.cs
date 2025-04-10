using UnityEngine;
using YG;

public class DataSaver : MonoBehaviour
{
    [SerializeField] private RockTotalCounter _rockTotalCounter;
    [SerializeField] private GameplayTimer _timer;

    [SerializeField] private GameScore _score;
    [SerializeField] private GemInventory _gemInventory;

    private void OnEnable()
    {
        _rockTotalCounter.AllCollected += SaveResult;
        _timer.Completed += SaveResult;
    }

    private void OnDisable()
    {
        _rockTotalCounter.AllCollected -= SaveResult;
        _timer.Completed -= SaveResult;
    }

    private void SaveResult()
    {
        SaveGems();
        SaveScore();
    }

    private void SaveGems()
    {
        YandexGame.savesData.gems += _gemInventory.CurrentAmount.Value;
    }

    private void SaveScore()
    {
        int previousScore = YandexGame.savesData.score;
        int currentScore = _score.Score.Value;

        if(previousScore < currentScore) 
        {
            YandexGame.savesData.score = currentScore;
        }
    }
}
