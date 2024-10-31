using System.Collections.Generic;
using UnityEngine;

public class TimerCardListView : MonoBehaviour
{
    [SerializeField] private TimerCardView _prefab;
    [SerializeField] private List<TimerCard> _cards;

    private void Awake()
    {
        Show(_cards);
    }

    private void Show(IEnumerable<TimerCard> cards)
    {
        foreach (TimerCard card in cards)
        {
            TimerCardView timerCard = Instantiate(_prefab, transform);
            timerCard.Show(card);
        }
    }
}
