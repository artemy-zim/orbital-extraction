using System;
using System.Collections;
using UnityEngine;

public abstract class Timer : MonoBehaviour
{
    private Coroutine _tickCoroutine;
    private float _value;

    public event Action Completed;
    public event Action<float> Ticking;

    protected void Launch(float time)
    {
        _value = Mathf.Clamp(time, 0, float.MaxValue);

        if(_tickCoroutine is not null)
        {
            Reset();
            _tickCoroutine = null;
        }

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
    }

    protected void Reset()
    {
        Completed?.Invoke();

        if (_tickCoroutine != null)
        {
            Ticking?.Invoke(_value);
            StopCoroutine(_tickCoroutine);
        }
    }

    protected abstract void OnEnable();
    protected abstract void OnDisable();
}
