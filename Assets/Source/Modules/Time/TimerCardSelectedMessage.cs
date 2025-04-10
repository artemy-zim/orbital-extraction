public class TimerCardSelectedMessage
{
    private readonly int _minutes;

    public int Minutes => _minutes;

    public TimerCardSelectedMessage(int minutes)
    {
        _minutes = minutes;
    }
}
