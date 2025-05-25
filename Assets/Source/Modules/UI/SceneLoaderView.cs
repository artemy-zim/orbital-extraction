using UnityEngine;
using UnityEngine.UI;

public class SceneLoaderView : MonoBehaviour
{
    [SerializeField] private Window _window;
    [SerializeField] private Slider _progressSlider;
    [SerializeField] private SceneLoader _sceneLoader;

    private void Awake()
    {
        _window.Hide();
    }

    private void OnEnable()
    {
        _sceneLoader.LoadingStarted += _window.Show;
        _sceneLoader.Loading += UpdateProgress;
        _sceneLoader.LoadingFinished += _window.Hide;
    }

    private void OnDisable()
    {
        _sceneLoader.LoadingStarted -= _window.Show;
        _sceneLoader.Loading -= UpdateProgress;
        _sceneLoader.LoadingFinished -= _window.Hide;
    }

    private void UpdateProgress(float progress)
    {
        _progressSlider.value = progress;
    }
}
