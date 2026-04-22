using AYellowpaper;
using System;
using UnityEngine;
using UnityEngine.UI;

internal class AdConfirmationWindow : MonoBehaviour
{
    [SerializeField] private InterfaceReference<IAnimator> _animator;
    [SerializeField] private Window _window;
    [SerializeField] private Button _acceptButton;
    [SerializeField] private Button _declineButton;

    public event Action Accepted;
    public event Action Declined;

    private void Awake()
    {
        _window.Hide();
    }

    private void OnEnable()
    {
        _acceptButton.onClick.AddListener(OnAccept);
        _declineButton.onClick.AddListener(OnDecline);
    }

    private void OnDisable()
    {
        _acceptButton.onClick.RemoveListener(OnAccept);
        _declineButton.onClick.RemoveListener(OnDecline);
    }

    public void Show()
    {
        _window.Show();
        _animator.Value.Play();
    }

    private void Hide()
    {
        _window.Hide();
        _animator.Value.Stop();
    }

    private void OnAccept()
    {
        Hide();
        Accepted?.Invoke();
    }

    private void OnDecline()
    {
        Hide();
        Declined?.Invoke();
    }
}
