using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public event Action<string, float> Changed;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void Start()
    {
        Init();
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void Init()
    {
        string parameter = GetParameter();

        if (PlayerPrefs.HasKey(parameter))
        {
            _slider.value = PlayerPrefs.GetFloat(parameter);
        }
        else
        {
            _slider.value = _slider.maxValue;
        }
    }

    private void ChangeVolume(float value)
    {
        string parameter = GetParameter();

        PlayerPrefs.SetFloat(parameter, value);
        Changed?.Invoke(parameter, value);
    }

    protected abstract string GetParameter();
}
