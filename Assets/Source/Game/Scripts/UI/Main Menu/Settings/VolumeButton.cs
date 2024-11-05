using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class VolumeButton : MonoBehaviour
{
    [SerializeField] private Button _actionButton;

    private readonly float _onValue = 0f;
    private readonly float _offValue = -80f;

    public event Action<string, float> Changed;
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
            SetValue(parameter, PlayerPrefs.GetFloat(parameter));
        }
        else
        {
            SetValue(parameter, _onValue);
        }
    }

    private void Toggle()
    {
        string parameter = GetParameter();

        if(PlayerPrefs.GetFloat(parameter) == _onValue)
        {
            SetValue(parameter, _offValue);
        }
        else
        {
            SetValue(parameter, _onValue);
        }
    }

    private bool GetToggleValue(float value)
    {
        return value == _onValue;
    }

    private void SetValue(string parameter, float value)
    {
        PlayerPrefs.SetFloat(parameter, value);
        Changed?.Invoke(parameter, value);
        Toggled?.Invoke(GetToggleValue(value));
    }

    protected abstract string GetParameter();
}
