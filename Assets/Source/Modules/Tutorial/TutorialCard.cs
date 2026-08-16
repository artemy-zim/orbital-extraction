using System;
using System.Linq;
using TMPro;
using UnityEngine;
using YG;

[Serializable]
internal class TutorialCard
{
    [SerializeField] private int _order;
    [SerializeField, TextArea(5, 10)] private string _enInfo;
    [SerializeField, TextArea(5, 10)] private string _ruInfo;
    [SerializeField, TextArea(5, 10)] private string _trInfo;
    [SerializeField] private Sprite _ruSprite;
    [SerializeField] private Sprite _enSprite;
    [SerializeField] private Sprite _trSprite;
    [SerializeField] private AudioClip _clip;
    private string _info;
    private TMP_FontAsset _font;
    private Sprite _sprite;


    public Sprite Sprite => _sprite;
    public TMP_FontAsset Font => _font;
    public string Info => _info;
    public AudioClip Clip => _clip;
    public int Order => _order;

    public void Init()
    {
        _info = YandexGame.lang switch
        {
            "ru" => _ruInfo,
            "en" => _enInfo,
            "tr" => _trInfo,
            _ => _enInfo,
        };

        TMP_FontAsset[] fonts = YandexGame.lang switch
        {
            "ru" => YandexGame.Instance.infoYG.fontsTMP.ru,
            "tr" => YandexGame.Instance.infoYG.fontsTMP.tr,
            "en" => YandexGame.Instance.infoYG.fontsTMP.en,
            _ => new TMP_FontAsset[0],
        };
        _font = fonts.FirstOrDefault();

        _sprite = YandexGame.lang switch
        {
            "ru" => _ruSprite,
            "en" => _enSprite,
            "tr" => _trSprite,
            _ => _enSprite,
        };
    }
}
