using AYellowpaper;
using DG.Tweening;
using System;
using UnityEngine;

public class PopUpWindowAnimator : MonoBehaviour, IAnimator
{
    [SerializeField] private InterfaceReference<ITransformable> _transformablePanel;
    [SerializeField] private Vector3 _animationOffset;
    [SerializeField] private float _scaleDuration;
    [SerializeField] private float _anchorPosDuration;

    private RectTransform _transform;
    private Sequence _sequence;

    private void Awake()
    {
        _transform = _transformablePanel.Value.GetTransform() as RectTransform;
    }

    public void Play()
    {
        _transform.localScale = Vector3.zero;
        _transform.localPosition = _animationOffset;

        Stop();

        _sequence = DOTween.Sequence()
            .Append(_transform.DOScale(Vector3.one, _scaleDuration)
                .SetEase(Ease.OutElastic))
            .Join(_transform.DOAnchorPos(Vector2.zero, _anchorPosDuration, false)
                .SetEase(Ease.OutExpo))
            .SetUpdate(true)
            .SetAutoKill(true)
            .Play();
    }

    public void Stop()
    {
        _sequence?.Kill();
    }

    private void OnDestroy()
    {
        Stop();
    }
}
