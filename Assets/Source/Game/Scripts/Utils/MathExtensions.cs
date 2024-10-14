using UnityEngine;

public static class MathExtensions
{
    public static float OneMinus(this float value)
    {
        value = ValidateValue(value);

        return 1 - value;  
    }

    private static float ValidateValue(float value)
    {
        value = Mathf.Clamp(value, 0, 1);

        return value;
    }
}
