using System;
using UnityEngine;

public class UIElement : MonoBehaviour, ITransformable
{
    public Transform GetTransform()
    {
        return TryGetComponent(out RectTransform transform) 
            ? transform 
            : throw new ArgumentNullException(nameof(transform));
    }
}
