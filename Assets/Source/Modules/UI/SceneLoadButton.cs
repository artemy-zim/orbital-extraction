using System;
using Tymski;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoadButton : MonoBehaviour
{
    [SerializeField] private SceneReference _scene;
    [SerializeField] private Button _button;

    private readonly Subject<SceneReference> _clicked = new();

    public IObservable<SceneReference> Clicked => _clicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if(LevelData.Instance.SelectedValue.Scene is not null)
        {
            if (_scene.ScenePath != string.Empty)
                _clicked.OnNext(_scene);
            else
                _clicked.OnNext(LevelData.Instance.SelectedValue.Scene);
        }
    }
}
