using System;
using Tymski;
using UnityEngine;

[Serializable]
public class LevelCard
{
    [SerializeField] private SceneReference _scene;
    [SerializeField] private int _order;

    public SceneReference Scene => _scene;
    public int Order => _order;
}
