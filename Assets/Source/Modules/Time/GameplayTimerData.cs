using UniRx;
using UnityEngine;

public class GameplayTimerData : MonoBehaviour
{
    public static GameplayTimerData Instance { get; private set; }
    public int SelectedMinutes { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);    
        }

        MessageBroker.Default.Receive<TimerCardSelectedMessage>()
            .Subscribe(message => SetSelectedMinutes(message.Minutes))
            .AddTo(this);
    }

    public void SetSelectedMinutes(int minutes)
    {
        SelectedMinutes = minutes;
    }
}
