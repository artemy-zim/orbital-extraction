using AYellowpaper;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PopUpAnimator : MonoBehaviour
{
    [SerializeField] private Button _actionButton; //UnityEvent try

    [SerializeField] private InterfaceReference<IAnimatable> _animatable;
    [SerializeField] private Vector3 _animationOffset;
    [SerializeField] private float _scaleDuration;
    [SerializeField] private float _anchorPosDuration;

    private Sequence _sequence;
    private RectTransform _transform;

    private void Awake()
    {
        _transform = _animatable.Value.GetTransform() as RectTransform;
        InitSequence();
    }

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(Play);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(Play);
    }

    public void Play()
    {
        _transform.localScale = Vector3.zero;
        _transform.localPosition = _animationOffset;

        _sequence.Restart();
    }

    private void InitSequence()
    {
        _sequence = DOTween.Sequence()
            .Append(_transform.DOScale(Vector3.one, _scaleDuration)
                .SetEase(Ease.OutElastic))
            .Join(_transform.DOAnchorPos(Vector2.zero, _anchorPosDuration, false)
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
