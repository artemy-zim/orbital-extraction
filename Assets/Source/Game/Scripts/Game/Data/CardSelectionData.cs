using UniRx;
using UnityEngine;

public class CardSelectionData<TCard> : MonoBehaviour
{
    public static CardSelectionData<TCard> Instance { get; private set; }
    public TCard SelectedValue { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        MessageBroker.Default.Receive<CardSelectedMessage<TCard>>()
            .Subscribe(message => SelectedValue = message.Value)
            .AddTo(this);
    }
}
