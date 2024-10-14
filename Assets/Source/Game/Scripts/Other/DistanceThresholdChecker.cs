using UnityEngine;

[System.Serializable]
public class DistanceThresholdChecker
{
    [SerializeField] private float _threshold;

    private Transform _transform;
    private ITarget _target;

    public void Init(Transform transform, ITarget target)
    {
        _transform = transform;
        _target = target;
    }

    public bool IsFar()
    {
        float distance = Vector3.Distance(_transform.position, _target.GetPosition());

        return distance > _threshold;
    }
}
