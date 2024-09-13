using System;
using System.Collections;
using UnityEngine;

public abstract class Timer : MonoBehaviour
{
    [SerializeField] private float _value;

    private Coroutine _tickCoroutine;

    public float DefaultValue => _value;

    public event Action Completed;
    public event Action<float> Ticking;

    private void OnValidate()
    {
        _value = Mathf.Clamp(_value, 0, float.MaxValue);
    }

    protected void Launch()
    {
        Reset();

        _tickCoroutine = StartCoroutine(OnTickCoroutine());
    }

    protected void Reset()
    {
        if(_tickCoroutine != null)
        {
            Ticking?.Invoke(_value);
            StopCoroutine(_tickCoroutine);
        }
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

    protected abstract void OnEnable();
    protected abstract void OnDisable();
}
