using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioPanelView : MonoBehaviour
{
    [SerializeField] private AudioPanel _audioPanel;
    [SerializeField] private TextMeshProUGUI _volumeStatusText;

    [SerializeField] private Button _showButton;
    [SerializeField] private PanelAnimator _panelAnimator;

    private void OnEnable()
    {
        _showButton.onClick.AddListener(_panelAnimator.Play);
        _audioPanel.VolumeToggled += SetStatus;
    }

    private void OnDisable()
    {
        _showButton.onClick.RemoveListener(_panelAnimator.Play);
        _audioPanel.VolumeToggled -= SetStatus;
    }

    private void SetStatus(bool isVolumeOn)
    {
        _volumeStatusText.text = isVolumeOn ? "On" : "Off";
    }
}
