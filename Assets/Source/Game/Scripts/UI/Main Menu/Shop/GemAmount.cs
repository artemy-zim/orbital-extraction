using UniRx;
using YG;
using UnityEngine;

public class GemAmount : MonoBehaviour
{
    private readonly ReactiveProperty<int> _amountProperty = new(YandexGame.savesData.gems);

    public IReadOnlyReactiveProperty<int> AmountProperty => _amountProperty;

    public void Add(int amount)
    {
        if (amount <= 0)
            return;

        _amountProperty.Value += amount;
    }
}
