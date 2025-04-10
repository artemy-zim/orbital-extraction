using System;
using UnityEngine;

[Serializable]
public class InventoryUpgrade
{
    [SerializeField] private int _cost;
    [SerializeField] private int _capacity;
    [SerializeField] private Sprite _sprite;
    //[SerializeField] private Material _material;
    //[SerializeField] private Mesh _mesh;

    public int Cost => _cost;
    public int Capacity => _capacity;
    public Sprite Sprite => _sprite;
   // public Material Material => _material;
   // public Mesh Mesh => _mesh;
}
