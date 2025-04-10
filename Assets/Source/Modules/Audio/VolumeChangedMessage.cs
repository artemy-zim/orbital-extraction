public class VolumeChangedMessage
{
    public VolumeChangedMessage(string parameter, float value) 
    {
        Parameter = parameter;
        Value = value;
    }

    public string Parameter { get; }
    public float Value { get; }
}
