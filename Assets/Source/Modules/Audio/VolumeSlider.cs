using UniRx;
using UnityEngine;
using UnityEngine.UI;

public abstract class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(CallEvent);
    }

    private void Start()
    {
        Init();
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(CallEvent);
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

    private void CallEvent(float value)
    {
        string parameter = GetParameter();

        MessageBroker.Default.Publish(new VolumeChangedMessage(parameter, value));
    }

    protected abstract string GetParameter();
}
