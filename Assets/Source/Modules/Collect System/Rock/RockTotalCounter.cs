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
        _rocksAmount = FindObjectsOfType(typeof(Rock)).Length;

        _rockInventory.CurrentAmount
            .Subscribe(amount => AreRocksCollected(amount))
            .AddTo(this);
    }

    private void AreRocksCollected(int rocksCollected)
    {
        if (rocksCollected < _rocksAmount)
            return;

        AllCollected?.Invoke();
    }
}
