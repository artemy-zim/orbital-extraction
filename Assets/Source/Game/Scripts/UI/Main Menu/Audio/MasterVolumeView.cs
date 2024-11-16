using TMPro;
using UnityEngine;

public class MasterVolumeView : MonoBehaviour
{
    [SerializeField] private VolumeButton _volumeButton;

    [SerializeField] private TextMeshProUGUI _volumeStatusText;

    private void OnEnable()
    {
        _volumeButton.Toggled += SetStatus;
    }

    private void OnDisable()
    {
        _volumeButton.Toggled -= SetStatus;
    }

    private void SetStatus(bool isVolumeOn)
    {
        _volumeStatusText.text = isVolumeOn ? "On" : "Off";
    }
}
