using System;
using UnityEngine;

public class UIElement : MonoBehaviour, IAnimatable
{
    public Transform GetTransform()
    {
        return TryGetComponent(out RectTransform transform) 
            ? transform 
            : throw new ArgumentNullException(nameof(transform));
    }
}
