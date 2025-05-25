using UnityEngine;

public class GameplayWindow : MonoBehaviour
{
    [SerializeField] private Window _window;

    public void Show()
    {
        _window.Show();
    }

    public void Hide()
    {
        _window.Hide();
    }
}
