using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class TimerCard
{
    [SerializeField, Min(1)] private int _minutes;
    [SerializeField] private Color _iconColor;

    public Color Color => _iconColor;
    public int Minutes => _minutes;
}
