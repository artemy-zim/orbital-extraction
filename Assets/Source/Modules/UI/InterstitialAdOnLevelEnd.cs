using UnityEngine;
using YG;

internal class InterstitialAdOnLevelEnd : MonoBehaviour
{
    [SerializeField] private GameplayTimer _timer;

    private void OnEnable()
    {
        _timer.Completed += ShowAd;
    }

    private void OnDisable()
    {
        _timer.Completed -= ShowAd;
    }

    private void ShowAd()
    {
        YandexGame.FullscreenShow();
    }
}
