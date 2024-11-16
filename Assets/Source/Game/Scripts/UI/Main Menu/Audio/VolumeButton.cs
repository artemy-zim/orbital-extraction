using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public abstract class VolumeButton : MonoBehaviour
{
    [SerializeField] private Button _actionButton;

    private readonly float _onValue = 1f;
    private readonly float _offValue = 0.0001f;

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

    private bool GetToggleValue(float value)
    {
        return value == _onValue;
    }

    private void CallEvent(string parameter, float value)
    {
        MessageBroker.Default.Publish(new VolumeChangedMessage(parameter, value));
        Toggled?.Invoke(GetToggleValue(value));
    }

    protected abstract string GetParameter();
}
