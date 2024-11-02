using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class TimerPanel : MonoBehaviour
{
    [SerializeField] private Button _playButton;

    private void Awake()
    {
        MessageBroker.Default.Receive<TimerCardSelectedMessage>()
            .Subscribe(message => TryActivatePlayButton(message.Minutes))
            .AddTo(this);

        _playButton.interactable = false;
    }

    private void TryActivatePlayButton(int minutes)
    {
        if(minutes > 0)
        {
            _playButton.interactable = true;
        }
    }
}
