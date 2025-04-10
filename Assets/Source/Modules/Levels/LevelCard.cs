using System;
using Tymski;
using UnityEngine;

[Serializable]
public class LevelCard
{
    [SerializeField] private SceneReference _scene;
    [SerializeField] private int _levelCount;

    public SceneReference Scene => _scene;
    public int LevelCount => _levelCount;
}
