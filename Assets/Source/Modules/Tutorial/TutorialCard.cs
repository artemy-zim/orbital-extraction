using System;
using UnityEngine;
using YG;

[Serializable]
internal class TutorialCard
{
    [SerializeField] private int _order;
    [SerializeField, TextArea(5, 10)] private string _enInfo;
    [SerializeField, TextArea(5, 10)] private string _ruInfo;
    [SerializeField, TextArea(5, 10)] private string _trInfo;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private AudioClip _clip;
    private string _info;


    public Sprite Sprite => _sprite;
    public string Info => _info;
    public AudioClip Clip => _clip;
    public int Order => _order;

    public void InitLang()
    {
        _info = YandexGame.lang switch
        {
            "ru" => _ruInfo,
            "en" => _enInfo,
            "tr" => _trInfo,
            _ => _enInfo,
        };
    }
}
