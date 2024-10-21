using System;
using UnityEngine;

internal class VehicleMover : Mover, IMoverEvents
{
    private Vector2 _previousDirection;

    public event Action Started;
    public event Action Stopped;

    public override void SetDirection(Vector2 direction)
    {
        base.SetDirection(direction);

        TryCallEvent(direction);

        _previousDirection = direction;
    }

    private void TryCallEvent(Vector2 direction)
    {
        if(direction == Vector2.zero) 
        {
            Stopped?.Invoke();  
        }
        else if(_previousDirection == Vector2.zero)
        {
            Started?.Invoke();
        }
    }
}