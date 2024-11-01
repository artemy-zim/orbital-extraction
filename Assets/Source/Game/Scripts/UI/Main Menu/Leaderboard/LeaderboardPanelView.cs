using UnityEngine;
using UnityEngine.UI;

public class LeaderboardPanelView : MonoBehaviour
{
    [SerializeField] private Button _showButton;
    [SerializeField] private PanelAnimator _panelAnimator;

    private void OnEnable()
    {
        _showButton.onClick.AddListener(_panelAnimator.Play);
    }

    private void OnDisable()
    {
        _showButton.onClick.RemoveListener(_panelAnimator.Play);
    }
}
