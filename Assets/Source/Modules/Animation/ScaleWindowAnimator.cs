using AYellowpaper;
using DG.Tweening;
using UnityEngine;

public class ScaleWindowAnimator : MonoBehaviour, IAnimator
{
    [SerializeField] private InterfaceReference<ITransformable> _transformablePanel;

    [SerializeField] private Vector2 _startScale;
    [SerializeField] private float _endValueY;
    [SerializeField] private float _endValueX;
    [SerializeField] private float _scaleDurationY;
    [SerializeField] private float _scaleDurationX;

    private RectTransform _transform;
    private Sequence _sequence;

    private void Awake()
    {
        _transform = _transformablePanel.Value.GetTransform() as RectTransform;
    }

    public void Play()
    {
        _transform.localScale = _startScale;    

        Stop();

        _sequence = DOTween.Sequence()
            .Append(_transform.DOScaleY(_endValueY, _scaleDurationY)
                .SetEase(Ease.OutSine))
            .Append(_transform.DOScaleX(_endValueX, _scaleDurationX)
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
    
