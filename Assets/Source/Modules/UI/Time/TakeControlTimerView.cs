using UnityEngine;
using UnityEngine.UI;

internal class TakeControlTimerView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TakeControlTimer _timer;

    private void OnEnable()
    {
        _timer.Ticking += UpdateView;
        _timer.Disabled += HideImage;
        _timer.Enabled += ShowImage;
        _timer.Completed += HideImage;
    }

    private void OnDisable()
    {
        _timer.Ticking -= UpdateView;
        _timer.Disabled -= HideImage;
        _timer.Enabled -= ShowImage;
        _timer.Completed -= HideImage;
    }

    private void ShowImage()
    {
        _image.enabled = true;
    }

    private void HideImage()
    {
        _image.enabled = false;
    }

    private void UpdateView(float value)
    {
        _image.fillAmount = (value/_timer.DefaultValue).OneMinus();
    }
}
