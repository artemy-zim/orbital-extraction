using UnityEngine;
using UnityEngine.UI;

public class JoystickHighlighter : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    [SerializeField] private Image _rightDownFocus;
    [SerializeField] private Image _leftDownFocus;
    [SerializeField] private Image _leftTopFocus;
    [SerializeField] private Image _rightTopFocus;

    private void Update()
    {
        Vector2 direction = _joystick.Direction;

        ResetHighlight();

        if (direction == Vector2.zero) 
            return;

        Image targetImage = GetTargetImage(direction);
        targetImage.color = GetHighlightedColor(targetImage.color, direction);
    }

    private Color GetHighlightedColor(Color color, Vector2 direction)
    {
        float alpha = (Mathf.Abs(direction.x) + Mathf.Abs(direction.y)) / 2;

        return new Color(color.r, color.g, color.b, Mathf.Clamp01(alpha));
    }

    private Image GetTargetImage(Vector2 direction)
    {
        if (direction.x > 0 && direction.y > 0) 
            return _rightTopFocus;

        if (direction.x > 0 && direction.y < 0) 
            return _rightDownFocus;

        if (direction.x < 0 && direction.y > 0) 
            return _leftTopFocus;

        return _leftDownFocus;
    }

    private void ResetHighlight()
    {
        _rightTopFocus.color = GetHighlightedColor(_rightTopFocus.color, Vector2.zero);
        _rightDownFocus.color = GetHighlightedColor(_rightDownFocus.color, Vector2.zero);
        _leftTopFocus.color = GetHighlightedColor(_leftTopFocus.color, Vector2.zero);
        _leftDownFocus.color = GetHighlightedColor(_leftDownFocus.color, Vector2.zero);
    }
}
