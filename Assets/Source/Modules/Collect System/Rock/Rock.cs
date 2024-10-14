using System;
using UnityEngine;

public class Rock : MonoBehaviour, ICollectable
{
    public event Action<ICollectable> Collected;

    public void OnCollect(ITarget collector)
    {
        throw new NotImplementedException();
    }
}
