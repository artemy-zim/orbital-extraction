using UnityEngine;
using UnityEngine.UI;

public class SceneLoaderView : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Slider _progressSlider;

    private void Awake()
    {
        HideLoadingScreen();
    }

    private void OnEnable()
    {
        SceneLoader.Instance.LoadingStarted += ShowLoadingScreen;
        SceneLoader.Instance.Loading += UpdateProgress;
        SceneLoader.Instance.LoadingFinished += HideLoadingScreen;
    }

    private void OnDisable()
    {
        SceneLoader.Instance.LoadingStarted -= ShowLoadingScreen;
        SceneLoader.Instance.Loading -= UpdateProgress;
        SceneLoader.Instance.LoadingFinished -= HideLoadingScreen;
    }

    private void ShowLoadingScreen()
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
    }

    private void HideLoadingScreen()
    {
        _canvasGroup.alpha = 0f;
        _canvasGroup.blocksRaycasts = false;
    }

    private void UpdateProgress(float progress)
    {
        _progressSlider.value = progress;
    }
}
