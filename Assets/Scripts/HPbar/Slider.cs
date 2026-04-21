using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class Slider : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private UnityEngine.UI.Slider _slider;
    [SerializeField] private float _smoothTime;

    private float _targetValue;
    private float _velocity;
    //private Coroutine _changeCoroutine;

    private void OnEnable()
    {
        _health.HealthChanged += HandleHealthChanged;
    }

    private void Start()
    {
        _targetValue = NormalizedHealth();
        StartCoroutine(ChangeHealth());
    }

    private void OnDisable()
    {
        _health.HealthChanged -= HandleHealthChanged;
    }

    private IEnumerator ChangeHealth()
    {
        while(Mathf.Approximately(_slider.value, _targetValue) == false)
        {
            _slider.value = Mathf.SmoothDamp(_slider.value, _targetValue, ref _velocity, _smoothTime);
            yield return null;
        }

        _slider.value = _targetValue;
    }

    private void HandleHealthChanged(float current, float max)
    {
        _targetValue = current / max;

        StartCoroutine(ChangeHealth());
    }

    private float NormalizedHealth()
    {
        if (_health.Max <= 0f)
            return 0f;

        Debug.Log(_health.Current / _health.Max);

        return _health.Current / _health.Max;
    }
}
