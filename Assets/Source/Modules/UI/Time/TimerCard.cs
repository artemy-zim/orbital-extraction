using System;
using UnityEngine;

[Serializable]
public class TimerCard
{
    [SerializeField, Min(1)] private int _minutes;
    [SerializeField] private Color _iconColor;

    public Color IconColor => _iconColor;
    public int Minutes => _minutes;
}
