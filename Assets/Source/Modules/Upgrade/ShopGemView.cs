using Assets.Source.Modules.Upgrade;
using TMPro;
using UnityEngine;
using YG;

public class ShopGemView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private UpgradeShop _bagShop;
    [SerializeField] private UpgradeShop _drillShop;
    [SerializeField] private ShopRewardedAd _rewardedAd;

    private void Start()
    {
        UpdateView();
    }

    private void OnEnable()
    {
        _bagShop.OnBought += UpdateView;
        _drillShop.OnBought += UpdateView;
        _rewardedAd.OnGemsRewarded += UpdateView;
    }

    private void OnDisable()
    {
        _bagShop.OnBought -= UpdateView;
        _drillShop.OnBought -= UpdateView;
        _rewardedAd.OnGemsRewarded -= UpdateView;
    }

    private void UpdateView()
    {
        _text.text = YandexGame.savesData.gems.ToString();
    }
}
