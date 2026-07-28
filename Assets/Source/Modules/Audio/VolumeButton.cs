using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using YG;

public abstract class VolumeButton : MonoBehaviour
{
    [SerializeField] private Button _actionButton;

    private readonly float _onValue = 1f;
    private readonly float _offValue = 0.0001f;

    private string _onString;
    private string _offString;

    public event Action<string> TextSet;
    public event Action<bool> Toggled;

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(Toggle);
    }

    private void Start()
    {
        Init();
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(Toggle);
    }

    private void Init()
    {
        string parameter = GetParameter();
        string lang = YandexGame.lang;

        switch (lang)
        {
            case "ru":
                SetLang("Вкл", "Выкл");

                break;
            case "en":
                SetLang("On", "Off");

                break;
            case "tr":
                SetLang("açık", "kapalı");

                break;
            default:
                SetLang("On", "Off");

                break;
        }

        if (PlayerPrefs.HasKey(parameter))
        {
            CallEvent(parameter, PlayerPrefs.GetFloat(parameter));
        }
        else
        {
            CallEvent(parameter, _onValue);
        }
    }

    private void Toggle()
    {
        string parameter = GetParameter();

        if(PlayerPrefs.GetFloat(parameter) == _onValue)
        {
            CallEvent(parameter, _offValue);
        }
        else
        {
            CallEvent(parameter, _onValue);
        }
    }

    private void SetLang(string on, string off)
    {
        _onString = on;
        _offString = off;
    }

    private bool GetToggleValue(float value)
    {
        return value == _onValue;
    }

    private void CallEvent(string parameter, float value)
    {
        MessageBroker.Default.Publish(new VolumeChangedMessage(parameter, value));

        bool isVolumeOn = GetToggleValue(value);
        Toggled?.Invoke(isVolumeOn);
        TextSet?.Invoke(isVolumeOn ? _onString : _offString);
    }

    protected abstract string GetParameter();
}
