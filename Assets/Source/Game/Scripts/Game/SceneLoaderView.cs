using UnityEngine;
using UnityEngine.UI;

public class SceneLoaderView : MonoBehaviour
{
    [SerializeField] private Window _window;
    [SerializeField] private Slider _progressSlider;

    private void Awake()
    {
        _window.Hide();
    }

    private void OnEnable()
    {
        SceneLoader.Instance.LoadingStarted += _window.Show;
        SceneLoader.Instance.Loading += UpdateProgress;
        SceneLoader.Instance.LoadingFinished += _window.Hide;
    }

    private void OnDisable()
    {
        SceneLoader.Instance.LoadingStarted -= _window.Show;
        SceneLoader.Instance.Loading -= UpdateProgress;
        SceneLoader.Instance.LoadingFinished -= _window.Hide;
    }

    private void UpdateProgress(float progress)
    {
        _progressSlider.value = progress;
    }
}
