internal class ScoreExpressionData
{
    internal ScoreExpressionData(int resourceCount, int multiplier, int total)
    {
        ResourceCount = resourceCount;
        Multiplier = multiplier;
        Total = total;
    }

    public int ResourceCount { get; }
    public int Multiplier { get; }
    public int Total { get; }
}
