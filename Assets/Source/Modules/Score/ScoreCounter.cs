using UniRx;
using UnityEngine;

internal abstract class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int _multiplier;

    private readonly ReactiveProperty<ScoreExpressionData> _expression = new();
    public IReadOnlyReactiveProperty<ScoreExpressionData> Expression => _expression;

    public int Calculate()
    {
        Inventory inventory = GetInventory();
        int total = _multiplier * inventory.CurrentAmount.Value;

        _expression.Value = new ScoreExpressionData(inventory.CurrentAmount.Value, _multiplier, total);

        return total;
    }

    protected abstract Inventory GetInventory();
}
