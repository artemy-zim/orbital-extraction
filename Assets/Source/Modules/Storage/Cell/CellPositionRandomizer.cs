using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class CellPositionRandomizer
{
    [SerializeField] private float _maxOffset;

    public void Shuffle(Vector3 center, Cell cell)
    {
        cell.transform.position = center + (Random.insideUnitSphere * _maxOffset);
    }

    public void Shuffle(Cell cell)
    {
        cell.transform.position += Random.insideUnitSphere * _maxOffset;
    }
}
