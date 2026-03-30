using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _max;
    [SerializeField] private float _baseDamage;
    [SerializeField] private string _name;

    private float _current;

    public event Action Exhausted;

    private void Awake()
    {
        _current = _max;
    }

    public void Reduce()
    {
        _current -= _baseDamage;
        Debug.Log($"Здоровье {_name}: {_current}");

        if (_current <= 0)
            Exhausted?.Invoke();
    }

    public void ReceiveHeal(float Heal)
    {
        if (_current < _max)
            _current += Heal;

        if (_current > _max)
            _current = _max;

        Debug.Log($"Здоровье {_name}: {_current}");
    }
}
