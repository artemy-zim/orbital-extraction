using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class VolumeButtonAnimator : MonoBehaviour
{
    [SerializeField] private AudioPanel _audioPanel;

    [SerializeField] private Image _iconOn;
    [SerializeField] private Image _iconOff;
    [SerializeField, Min(0)] private float _duration;

    private float _iconsDistance;
    private float _iconOnInitialPositionX;
    private float _iconOffInitialPositionX;

    private void Awake()
    {
        _iconsDistance = Mathf.Abs(_iconOn.rectTransform.localPosition.x - _iconOff.rectTransform.localPosition.x);
        _iconOnInitialPositionX = _iconOn.rectTransform.localPosition.x;
        _iconOffInitialPositionX = _iconOff.rectTransform.localPosition.x;
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
        float distance = GetMoveDistance(isVolumeOn);

        Play(distance);
    }

    private float GetMoveDistance(bool isVolumeOn)
    {
        return isVolumeOn ? -_iconsDistance : 0;
    }

    private void Play(float distance)
    {
        float targetPosIconOn = _iconOnInitialPositionX + distance;
        float targetPosIconOff = _iconOffInitialPositionX + distance;

        _iconOn.rectTransform.DOLocalMoveX(targetPosIconOn, _duration).SetEase(Ease.InOutQuad);
        _iconOff.rectTransform.DOLocalMoveX(targetPosIconOff, _duration).SetEase(Ease.InOutQuad);
    }

    private void OnDestroy()
    {
        _iconOn.rectTransform.DOKill();
        _iconOff.rectTransform.DOKill();
    }
}
