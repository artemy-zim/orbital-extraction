using UnityEngine;
using UnityEngine.UI;

internal class TakeControlTimerView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TakeControlTimer _timer;

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
        _image.fillAmount = (value/_timer.DefaultValue).OneMinus();
    }
}
