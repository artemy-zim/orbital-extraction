using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using YG;

public class ShopGemView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        UpdateView();
    }

    private void UpdateView()
    {
        _text.text = YandexGame.savesData.gems.ToString();
    }
}
