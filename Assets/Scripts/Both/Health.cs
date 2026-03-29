using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _max;
    [SerializeField] private float _baseDamage;
    [SerializeField] private string _name;

    private float _current;

    public event Action HealthExhausted;

    private void Awake()
    {
        _current = _max;
    }

    public void TakeDamage()
    {
        _current -= _baseDamage;
        Debug.Log($"Здоровье {_name}: {_current}");

        if (_current <= 0)
            HealthExhausted?.Invoke();
    }

    public void ReceiveHeal(float Heal)
    {
        if (_current < _max)
            _current += Heal;

        Debug.Log($"Здоровье {_name}: {_current}");
    }
}
