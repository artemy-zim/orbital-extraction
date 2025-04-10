using System;
using UnityEngine;

[Serializable]
internal class TutorialCard
{
    [SerializeField] private int _order;
    [SerializeField, TextArea(5, 10)] private string _info;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private AudioClip _clip;

    public Sprite Sprite => _sprite;
    public string Info => _info;
    public AudioClip Clip => _clip;
    public int Order => _order;
}
