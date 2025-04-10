using System.Collections.Generic;
using UnityEngine;

public class TimerCardListView : MonoBehaviour
{
    [SerializeField] private TimerCardView _prefab;
    [SerializeField] private List<TimerCard> _cards;

    private void Awake()
    {
        Render();
    }

    private void Render()
    {
        foreach (TimerCard card in _cards)
        {
            TimerCardView timerCard = Instantiate(_prefab, transform);
            timerCard.Render(card);
        }
    }
}
