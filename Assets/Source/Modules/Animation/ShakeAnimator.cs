using AYellowpaper;
using DG.Tweening;
using UnityEngine;

public class ShakeAnimator : MonoBehaviour
{
    [SerializeField] private InterfaceReference<ITransformable> _animatable;

    [SerializeField] private Vector3 _angle;
    [SerializeField] private float _shakeDuration;
    [SerializeField] private float _pauseDuration;
    [SerializeField] private int _vibrationsAmount;
    [SerializeField, Min(-1)] private int _loopsAmount;

    private RectTransform _transform;
    private Sequence _sequence;

    private void Awake()
    {
        _sequence = DOTween.Sequence();
        _transform = _animatable.Value.GetTransform() as RectTransform;

        Play();
    }

    private void Play()
    {
        for(int i = 0; i < _vibrationsAmount; i++)
        {
            Vector3 angle = IsEven(i) ? _angle : -_angle;

            AppendAngle(angle);   
        }

        AppendAngle(Vector3.zero);
        _sequence.AppendInterval(_pauseDuration);
        _sequence.SetLoops(_loopsAmount);
    }

    private void AppendAngle(Vector3 angle)
    {
        _sequence.Append(_transform.DOLocalRotate(angle, _shakeDuration))
            .SetEase(Ease.InOutSine);
    }

    private bool IsEven(float number)
    {
        int divider = 2;

        return number % divider == 0;
    }

    private void OnDestroy()
    {
        _sequence.Kill();
    }
}
