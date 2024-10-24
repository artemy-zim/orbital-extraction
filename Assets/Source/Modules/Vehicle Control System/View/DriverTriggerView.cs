using UnityEngine;

internal class DriverTriggerView : MonoBehaviour
{
    [SerializeField] private TakeControlTimer _timer;
    [SerializeField] private DriverTrigger _trigger;
    [SerializeField] private SphereCollider _collider;

    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float groundOffset;

    private int _vertexCount;

    private void Awake()
    {
        _vertexCount = _lineRenderer.positionCount;
        _lineRenderer.loop = true;
    }

    private void OnEnable()
    {
        _trigger.EnterTriggered += Draw;
        _trigger.ExitTriggered += Erase;
        _timer.Completed += Erase;
    }

    private void OnDisable()
    {
        _trigger.EnterTriggered -= Draw;
        _trigger.ExitTriggered -= Erase;
        _timer.Completed -= Erase;
    }

    private void Draw()
    {
        _lineRenderer.positionCount = _vertexCount;
        Vector3 center = _collider.transform.TransformPoint(_collider.center);
        float radius = _collider.radius * Mathf.Max(_collider.transform.localScale.x, _collider.transform.localScale.y, _collider.transform.localScale.z);

        Render(center, radius);
    }

    private void Erase()
    {
        _lineRenderer.positionCount = 0;
    }

    private void Render(Vector3 center, float radius)
    {
        int maxAngleDeg = 360;
        float angleStep = maxAngleDeg / _lineRenderer.positionCount * Mathf.Deg2Rad;

        for (int i = 0; i < _lineRenderer.positionCount; i++)
        {
            float angle = i * angleStep;
            Vector2 currentPosition = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;

            _lineRenderer.SetPosition(i, new Vector3(center.x + currentPosition.x, groundOffset, center.z + currentPosition.y));
        }
    }
}
