using UnityEngine;
using UnityEngine.UI;

internal class TakeControlTimerView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Timer _timer;

    private float _maxValue;

    private void Awake()
    {
        _maxValue = _timer.DefaultValue;
        UpdateView(_maxValue);
    }

    private void OnEnable()
    {
        _timer.Ticking += UpdateView;
    }

    private void OnDisable()
    {
        _timer.Ticking -= UpdateView;
    }

    private void UpdateView(float value)
    {
        _image.fillAmount = 1-(value/_maxValue); //Extension method for OneMinus
    }
}
