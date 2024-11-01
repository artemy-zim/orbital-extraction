using AYellowpaper;
using DG.Tweening;
using UnityEngine;

public class VolumeButtonAnimator : MonoBehaviour
{
    [SerializeField] private AudioPanel _audioPanel;

    [SerializeField] private InterfaceReference<IAnimatable> _animatable;
    [SerializeField, Min(0)] private float _duration;
    [SerializeField] private float _distanceX;

    private RectTransform _transform;
    private float _initialPositionX;

    private void Awake()
    {
        _transform = _animatable.Value.GetTransform() as RectTransform;
        _initialPositionX = _transform.localPosition.x;
    }

    private void OnEnable()
    {
        _audioPanel.VolumeToggled += OnVolumeToggled;
    }

    private void OnDisable()
    {
        _audioPanel.VolumeToggled -= OnVolumeToggled;
    }

    private void OnVolumeToggled(bool isVolumeOn)
    {
        float distance = isVolumeOn ? -_distanceX : 0;

        _transform.DOLocalMoveX(_initialPositionX + distance, _duration)
            .SetEase(Ease.InOutQuad);

        Debug.Log(distance);
    }
}
