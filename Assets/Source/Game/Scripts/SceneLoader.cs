using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    public event Action LoadingStarted;
    public event Action<float> Loading;
    public event Action LoadingFinished;

    private void Awake()
    {
        if (Instance == null && Instance != this)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadGameScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
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
