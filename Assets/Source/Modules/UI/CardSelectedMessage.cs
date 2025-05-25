public class CardSelectedMessage<T>
{
    private readonly T _value;
    public T Value => _value;

    public CardSelectedMessage(T value)
    {
        _value = value;
    }
}
