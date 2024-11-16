using UniRx;
using UnityEngine;

internal abstract class ResourceScore : MonoBehaviour
{
    [SerializeField] private int _multiplier;

    private readonly ReactiveProperty<ScoreExpressionData> _expression = new();
    public IReadOnlyReactiveProperty<ScoreExpressionData> Expression => _expression;

    public int Calculate()
    {
        ResourceCounter counter = GetCounter();
        int total = _multiplier * counter.Amount.Value;
        _expression.Value = new ScoreExpressionData(counter.Amount.Value, _multiplier, total);

        return total;
    }

    protected abstract ResourceCounter GetCounter();
}
