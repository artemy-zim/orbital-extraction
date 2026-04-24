using UnityEngine;
using UnityEngine.UI;
using YG;

internal class RewardedGemDoubler : MonoBehaviour
{
    [SerializeField] private GameplayTimer _timer;
    [SerializeField] private GemStorage _gemStorage;
    [SerializeField] private Button _doubleButton;
    [SerializeField] private AdConfirmationWindow _confirmationWindow;

    private const int AdId = 1;
    private bool _rewarded;

    private void OnEnable()
    {
        _timer.Completed += OnLevelCompleted;
        _doubleButton.onClick.AddListener(OnDoubleButtonClick);
        _confirmationWindow.Accepted += ShowAd;
        YandexGame.RewardVideoEvent += OnRewarded;
    }

    private void OnDisable()
    {
        _timer.Completed -= OnLevelCompleted;
        _doubleButton.onClick.RemoveListener(OnDoubleButtonClick);
        _confirmationWindow.Accepted -= ShowAd;
        YandexGame.RewardVideoEvent -= OnRewarded;
    }

    private void OnLevelCompleted()
    {
        _rewarded = false;
        _doubleButton.gameObject.SetActive(true);
    }

    private void OnDoubleButtonClick()
    {
        _confirmationWindow.Show();
    }

    private void ShowAd()
    {
        YandexGame.RewVideoShow(AdId);
    }

    private void OnRewarded(int id)
    {
        if (id != AdId || _rewarded)
            return;

        _rewarded = true;

        int currentGems = _gemStorage.FilledCellsCount.Value;
        YandexGame.savesData.gems += currentGems;
        YandexGame.SaveProgress();

        _doubleButton.gameObject.SetActive(false);
    }
}
