using System;
using System.Collections;
using UnityEngine;

public abstract class Timer : MonoBehaviour
{
    private Coroutine _tickCoroutine;
    private float _value;

    public event Action Completed;
    public event Action<float> Ticking;

    protected void Init(float value)
    {
        _value = Mathf.Clamp(value, 0, float.MaxValue); 
    }

    protected void Launch()
    {
        Reset();

        _tickCoroutine = StartCoroutine(OnTickCoroutine());
    }

    private IEnumerator OnTickCoroutine()
    {
        float currentValue = _value;

        while(currentValue > 0) 
        {
            currentValue -= Time.deltaTime;
            Ticking?.Invoke(currentValue);

            yield return null;
        }

        Reset();
        Completed?.Invoke();
    }

    protected void Reset()
    {
        if (_tickCoroutine != null)
        {
            Ticking?.Invoke(_value);
            StopCoroutine(_tickCoroutine);
        }
    }

    protected abstract void OnEnable();
    protected abstract void OnDisable();
}
