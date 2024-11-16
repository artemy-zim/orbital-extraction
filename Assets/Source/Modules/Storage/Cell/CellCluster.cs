using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UniRx;
using UnityEngine;

public class CellCluster : MonoBehaviour
{
    [SerializeField] private Cell _prefab;
    [SerializeField] private int _capacity;

    [SerializeField] private float _width;
    [SerializeField] private float _length;

    private readonly Collection<Cell> _cells = new();

    public bool HasEmptyCell => _cells.Any(cell => cell.IsEmpty);
    public bool HasFilledCell => _cells.Any(cell => cell.IsEmpty == false);
    
    public void Init(CellPositionRandomizer shuffler)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Cell cell = Instantiate(_prefab, GenerateCellPosition(), Quaternion.identity, transform);

            shuffler.Shuffle(cell);
            _cells.Add(cell);
        }
    }

    public Cell GetNextEmptyCell()
    {
        return _cells.FirstOrDefault(cell => cell.IsEmpty);
    }

    public Cell GetLastFilledCell()
    {
        return _cells.LastOrDefault(cell => cell.IsEmpty == false);
    }

    private Vector3 GenerateCellPosition()
    {
        Vector3 clusterPosition = transform.position;

        float randomWidth = Random.Range(clusterPosition.x, clusterPosition.x + _width);
        float randomLength = Random.Range(clusterPosition.z, clusterPosition.z + _length);

        return new Vector3(randomWidth, clusterPosition.y, randomLength);
    }
}
