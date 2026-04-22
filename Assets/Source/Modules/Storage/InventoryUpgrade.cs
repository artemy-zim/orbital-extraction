using System;
using UnityEngine;

[Serializable]
public class InventoryUpgrade
{
    [SerializeField] private int _id;
    [SerializeField] private int _cost;
    [SerializeField] private int _capacity;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Material _material;
    [SerializeField] private Mesh _mesh;
    [SerializeField] private float _gatherRadius;
    [SerializeField] private float _speed;

    public int Id => _id;
    public int Cost => _cost;
    public int Capacity => _capacity;
    public Sprite Sprite => _sprite;
    public Material Material => _material;
    public Mesh Mesh => _mesh;
    public float GatherRadius => _gatherRadius;
    public float Speed => _speed;
}
