using UnityEngine;
using YG;

public class DataSaver : MonoBehaviour
{
    [SerializeField] private GameplayTimer _timer;

    [SerializeField] private GameScore _score;
    [SerializeField] private GemStorage _gemStorage;

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
        YandexGame.savesData.gems += _gemStorage.FilledCellsCount.Value;
        Debug.Log($"SAVED: {_gemStorage.FilledCellsCount.Value} gems.");
    }

    private void SaveScore()
    {
        int levelCount = LevelData.Instance.SelectedValue.Order - 1;

        int previousScore = YandexGame.savesData.levelScores[levelCount];
        int currentScore = _score.Score.Value;

        Debug.Log($"Previous score: {previousScore}");
        Debug.Log($"Current score: {currentScore}");

        if (previousScore < currentScore) 
        {
            Debug.Log($"SAVED: {currentScore} score.");
            YandexGame.savesData.levelScores[levelCount] = currentScore;
        }
    }
}
