using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class TimerPanelView : MonoBehaviour
{
    [SerializeField] private Button _playButton;

    [SerializeField] private Button _timerSelectShowButton;
    [SerializeField] private PanelAnimator _panelAnimator;

    private void Awake()
    {
        MessageBroker.Default.Receive<TimerCardSelectedMessage>()
            .Subscribe(message => TryActivatePlayButton(message.Minutes))
            .AddTo(this);

        _playButton.interactable = false;
    }

    private void OnEnable()
    {
        _timerSelectShowButton.onClick.AddListener(_panelAnimator.Play);
    }

    private void OnDisable()
    {
        _timerSelectShowButton.onClick.RemoveListener(_panelAnimator.Play);
    }

    private void TryActivatePlayButton(int minutes)
    {
        if(minutes > 0)
        {
            _playButton.interactable = true;
        }
    }
}
