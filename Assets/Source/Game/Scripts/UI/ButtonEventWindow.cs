using UnityEngine;
using UnityEngine.UI;

public class ButtonEventWindow : MonoBehaviour
{
    [SerializeField] private Window _window;
    [SerializeField] private Button _showButton;
    [SerializeField] private Button _hideButton;

    private void OnEnable()
    {
        _showButton.onClick.AddListener(_window.Show);
        _hideButton.onClick.AddListener(_window.Hide);
    }

    private void OnDisable()
    {
        _showButton.onClick.RemoveListener(_window.Show);
        _hideButton.onClick.RemoveListener(_window.Hide);
    }
}
