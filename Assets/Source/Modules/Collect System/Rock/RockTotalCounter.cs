using System;
using UniRx;
using UnityEngine;

internal class RockTotalCounter : MonoBehaviour
{
    [SerializeField] private RockInventory _rockInventory;

    private int _rocksAmount;

    public event Action AllCollected;

    private void Awake()
    {
        _rockInventory.CurrentAmount
            .Subscribe(amount => CheckIfAllRocksCollected(amount))
            .AddTo(this);

        _rocksAmount = FindObjectsOfType(typeof(Rock)).Length;
    }

    private void CheckIfAllRocksCollected(int rocksCollected)
    {
        if (rocksCollected < _rocksAmount)
            return;

        AllCollected?.Invoke();
    }
}
