using System.Collections.Generic;
using UnityEngine;
using YG;

public class CardListView<TCard> : MonoBehaviour
{
    [SerializeField] private CardView<TCard> _prefab;
    [SerializeField] private List<TCard> _cards;

    private void Awake()
    {
        Render();
    }

    private void Render()
    {
        foreach(TCard card in _cards)
        {
            CardView<TCard> cardView = Instantiate(_prefab, transform);
            cardView.Render(card);
        }
    }
}
