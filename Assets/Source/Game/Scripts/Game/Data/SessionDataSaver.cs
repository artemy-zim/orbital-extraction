using UnityEngine;
using YG;

public class SessionDataSaver : MonoBehaviour
{
    [SerializeField] private GameplayTimer _timer;

    [SerializeField] private GameScore _score;
    [SerializeField] private GemStorage _gemStorage;

    private void OnEnable()
    {
        _timer.Completed += SaveSessionResult;
    }

    private void OnDisable()
    {
        _timer.Completed -= SaveSessionResult;
    }

    private void SaveSessionResult()
    {
        SaveGems();
        SaveScore();

        YandexGame.SaveProgress();
    }

    private void SaveGems()
    {
        YandexGame.savesData.gems += _gemStorage.FilledCellsCount.Value;
    }

    private void SaveScore()
    {
        int levelCount = LevelData.Instance.SelectedValue.Order - 1;

        int previousScore = YandexGame.savesData.levelScores[levelCount];
        int currentScore = _score.Calculate();

        if (previousScore < currentScore) 
        {
            YandexGame.savesData.levelScores[levelCount] = currentScore;
        }
    }
}
