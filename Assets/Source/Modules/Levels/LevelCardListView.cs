using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCardListView : MonoBehaviour
{
    [SerializeField] private TimerCardView _prefab;
    [SerializeField] private List<TimerCard> _cards;

    private void Awake()
    {
        Render();
    }

    private void Render()
    {
        foreach(TimerCard card in _cards)
        {
            TimerCardView cardView = Instantiate(_prefab, transform);
            cardView.Render(card);
        }
    }
}
