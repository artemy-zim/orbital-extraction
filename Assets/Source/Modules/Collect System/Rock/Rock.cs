using System;
using UnityEngine;

public class Rock : MonoBehaviour, ICollectable
{
    public void OnCollect(Cell cell)
    {
        throw new NotImplementedException();
    }
}
