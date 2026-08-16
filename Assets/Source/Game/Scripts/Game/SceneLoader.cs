using System;
using System.Collections;
using System.IO;
using Tymski;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private SceneLoadButton[] _buttons = new SceneLoadButton[8];

    public event Action LoadingStarted;
    public event Action<float> Loading;
    public event Action LoadingFinished;

    private void Awake()
    {
        foreach (SceneLoadButton button in _buttons)
        {
            if (button != null)
                button.Clicked
            .Subscribe(reference => StartCoroutine(LoadSceneCoroutine(reference)))
            .AddTo(this);
        }
    }

    private IEnumerator LoadSceneCoroutine(SceneReference scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        float sceneLoadThreshold = 0.9f;

        LoadingStarted?.Invoke();

        while (operation.isDone == false)
        {
            float progress = Mathf.Clamp01(operation.progress / sceneLoadThreshold);
            Loading?.Invoke(progress);

            yield return null;
        }

        LoadingFinished?.Invoke();
    }
}
