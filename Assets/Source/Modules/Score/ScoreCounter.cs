using UniRx;
using UnityEngine;

internal abstract class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int _multiplier;

    private readonly ReactiveProperty<ScoreExpressionData> _expression = new();
    public IReadOnlyReactiveProperty<ScoreExpressionData> Expression => _expression;

    public int Calculate()
    {
        Storage storage = GetStorage();
        int total = _multiplier * storage.FilledCellsCount.Value;

        _expression.Value = new ScoreExpressionData(storage.FilledCellsCount.Value, _multiplier, total);

        return total;
    }

    protected abstract Storage GetStorage();
}
