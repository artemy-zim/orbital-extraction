using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Assets.Source.Modules.Upgrade
{
    internal class ShopRewardedAd : MonoBehaviour
    {
        [SerializeField] private Button _watchAdButton;
        [SerializeField] private AdConfirmationWindow _confirmationWindow;
        [SerializeField] private int _gemReward = 5;

        private const int AdId = 2;
        private const int MaxDailyViews = 3;

        public event Action OnGemsRewarded;

        private void Start()
        {
            UpdateButtonState();
        }

        private void OnEnable()
        {
            _watchAdButton.onClick.AddListener(OnWatchAdClick);
            _confirmationWindow.Accepted += ShowAd;
            YandexGame.RewardVideoEvent += OnRewarded;
        }

        private void OnDisable()
        {
            _watchAdButton.onClick.RemoveListener(OnWatchAdClick);
            _confirmationWindow.Accepted -= ShowAd;
            YandexGame.RewardVideoEvent -= OnRewarded;
        }

        private void OnWatchAdClick()
        {
            _confirmationWindow.Show();
        }

        private void ShowAd()
        {
            YandexGame.RewVideoShow(AdId);
        }

        private void OnRewarded(int id)
        {
            if (id != AdId)
                return;

            YandexGame.savesData.gems += _gemReward;
            IncrementViewCount();
            YandexGame.SaveProgress();

            UpdateButtonState();
            OnGemsRewarded?.Invoke();
        }

        private void UpdateButtonState()
        {
            ResetIfNewDay();
            _watchAdButton.interactable = YandexGame.savesData.shopAdViewsToday < MaxDailyViews;
        }

        private void IncrementViewCount()
        {
            ResetIfNewDay();
            YandexGame.savesData.shopAdViewsToday++;
            YandexGame.savesData.lastShopAdDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
        }

        private void ResetIfNewDay()
        {
            string today = DateTime.UtcNow.ToString("yyyy-MM-dd");

            if (YandexGame.savesData.lastShopAdDate != today)
            {
                YandexGame.savesData.shopAdViewsToday = 0;
                YandexGame.savesData.lastShopAdDate = today;
            }
        }
    }
}
