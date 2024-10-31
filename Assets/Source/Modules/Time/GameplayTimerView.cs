using TMPro;
using UnityEngine;

public class GameplayTimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Timer _timer;

    private readonly int _secondsPerMinute = 60;

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
        value = Mathf.CeilToInt(value);

        int minutes = Mathf.FloorToInt(value / _secondsPerMinute);
        int seconds = Mathf.FloorToInt(value % _secondsPerMinute);

        _text.text = $"{minutes}:{seconds:00}";
    }
}
