using AYellowpaper;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEventWindow : MonoBehaviour
{
    [SerializeField] private InterfaceReference<IAnimator> _animator;

    [SerializeField] private Window _window;
    [SerializeField] private Button _showButton;
    [SerializeField] private Button _hideButton;
    [SerializeField] private bool _isShownAtLaunch;

    private void Awake()
    {
        if(_isShownAtLaunch)
        {
            _window.Show();
        }
        else
        {
            _window.Hide();
        }
    }

    private void OnEnable()
    {
        _showButton.onClick.AddListener(OnShowButtonClick);
        _hideButton.onClick.AddListener(OnHideButtonClick);
    }

    private void OnDisable()
    {
        _showButton.onClick.RemoveListener(OnShowButtonClick);
        _hideButton.onClick.RemoveListener(OnHideButtonClick);
    }

    private void OnShowButtonClick()
    {
        _window.Show();
        _animator.Value.Play();
        _showButton.interactable = false;
    }

    private void OnHideButtonClick()
    {
        _window.Hide();
        _animator.Value.Stop();
        _showButton.interactable = true;
    }
}
