using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class CellShuffler
{
    [SerializeField] private float _maxDistance;

    public void Shuffle(Vector3 center, IReadOnlyCollection<Cell> cells)
    {
        foreach(var cell in cells)
        {
            cell.transform.position = center + (Random.insideUnitSphere * _maxDistance);
        }
    }
}
