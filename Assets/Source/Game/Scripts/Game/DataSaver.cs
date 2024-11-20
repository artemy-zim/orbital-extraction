using UniRx;
using UnityEngine;
using YG;

public class DataSaver : MonoBehaviour
{
    [SerializeField] private GameplayTimer _timer;
    [SerializeField] private GameScore _score;
    [SerializeField] private GemCounter _gemCounter;

    private void Awake()
    {
        _score.Score
            .Subscribe(value => SaveScore(value))
            .AddTo(this);
    }

    private void OnEnable()
    {
        _timer.Completed += SaveGems;
    }

    private void OnDisable()
    {
        _timer.Completed -= SaveGems;
    }

    private void SaveGems()
    {
        YandexGame.savesData.gems += _gemCounter.Amount.Value;
    }

    private void SaveScore(int score)
    {
        int previousScore = YandexGame.savesData.score;

        if(previousScore < score) 
        {
            YandexGame.savesData.score = score;
        }
    }
}
