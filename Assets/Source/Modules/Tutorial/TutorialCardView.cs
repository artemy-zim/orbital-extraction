using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
internal class TutorialCardView
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _image;
    [SerializeField] private AudioSource _audio;

    public void Render(TutorialCard card) 
    {
        _text.text = card.Info;
        _image.sprite = card.Sprite;
        _audio.clip = card.Clip;
        _audio.Play();
    }

}
