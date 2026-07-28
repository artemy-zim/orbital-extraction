using TMPro;
using UnityEngine;
using YG;

public class MasterVolumeView : MonoBehaviour
{
    [SerializeField] private VolumeButton _volumeButton;
    [SerializeField] private TextMeshProUGUI _volumeStatusText;

    private void OnEnable()
    {
        _volumeButton.TextSet += SetStatus;
    }

    private void OnDisable()
    {
        _volumeButton.TextSet -= SetStatus;
    }

    private void SetStatus(string text)
    {
        _volumeStatusText.text = text;
    }
}
