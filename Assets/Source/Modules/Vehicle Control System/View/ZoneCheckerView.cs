using UnityEngine;
using Vector3 = UnityEngine.Vector3;

internal class ZoneCheckerView : MonoBehaviour
{
    [SerializeField] private TakeControlTimer _timer;
    [SerializeField] private ZoneChecker _zoneChecker;

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
        _zoneChecker.DriverEntered += Draw;
        _zoneChecker.DriverExit += Erase;
        _timer.Completed += Erase;
    }

    private void OnDisable()
    {
        _zoneChecker.DriverEntered -= Draw;
        _zoneChecker.DriverExit -= Erase;
        _timer.Completed -= Erase;
    }

    private void Draw()
    {
        _lineRenderer.positionCount = _vertexCount;
        Render(_zoneChecker.Center, _zoneChecker.Radius);
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
