using System;

public interface IMoverEvents
{
    public event Action Started;
    public event Action Stopped;
    public event Action<float> Rotated;
}
