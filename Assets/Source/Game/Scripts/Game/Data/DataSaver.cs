using UnityEngine;
using YG;

public class DataSaver : MonoBehaviour
{
    [SerializeField] private GameplayTimer _timer;

    [SerializeField] private GameScore _score;
    [SerializeField] private GemInventory _gemInventory;

    private void OnEnable()
    {
        _timer.Completed += SaveResult;
    }

    private void OnDisable()
    {
        _timer.Completed -= SaveResult;
    }

    private void SaveResult()
    {
        SaveGems();
        SaveScore();

        YandexGame.SaveProgress();
    }

    private void SaveGems()
    {
        YandexGame.savesData.gems += _gemInventory.CurrentAmount.Value;
    }

    private void SaveScore()
    {
        int levelCount = LevelData.Instance.SelectedValue.Order - 1;

        int previousScore = YandexGame.savesData.levelScores[levelCount];
        int currentScore = _score.Score.Value;

        if(previousScore < currentScore) 
        {
            YandexGame.savesData.levelScores[levelCount] = currentScore;
        }
    }
}
