using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PanelAnimator : MonoBehaviour
{
    [SerializeField] private Image _image;

    [SerializeField] private Vector3 _animationOffset;
    [SerializeField] private float _scaleDuration;
    [SerializeField] private float _anchorPosDuration;

    private Sequence _sequence;

    private void Awake()
    {
        InitSequence();
    }

    public void Play()
    {
        _image.rectTransform.localScale = Vector3.zero;
        _image.transform.localPosition = _animationOffset;

        _sequence.Restart();
    }

    private void InitSequence()
    {
        _sequence = DOTween.Sequence()
            .Append(_image.rectTransform.DOScale(Vector3.one, _scaleDuration)
                .SetEase(Ease.OutElastic))
            .Join(_image.rectTransform.DOAnchorPos(Vector2.zero, _anchorPosDuration, false)
                .SetEase(Ease.OutExpo))
            .SetUpdate(true)
            .SetAutoKill(false)
            .Pause();
    }

    private void OnDestroy()
    {
        _sequence.Kill();
    }
}
