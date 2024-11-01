using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class TimerPanelView : MonoBehaviour
{
    [SerializeField] private Button _playButton;

    [SerializeField] private Button _showButton;
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
        _showButton.onClick.AddListener(_panelAnimator.Play);
    }

    private void OnDisable()
    {
        _showButton.onClick.RemoveListener(_panelAnimator.Play);
    }

    private void TryActivatePlayButton(int minutes)
    {
        if(minutes > 0)
        {
            _playButton.interactable = true;
        }
    }
}
