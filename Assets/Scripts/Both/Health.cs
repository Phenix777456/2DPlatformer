using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _max;
    [SerializeField] private string _name;

    public float Max => _max;

    public float Current { get; private set; }

    public event Action Exhausted;
    public event Action<float, float> HealthChanged;

    private void Awake()
    {
        Current = _max;
    }

    public void Reduce(float damage)
    {
        Current -= damage;
        HealthChanged?.Invoke(Current, _max);

        Debug.Log($"Здоровье {_name}: {Current}");

        if (Current <= 0)
            Exhausted?.Invoke();
    }

    public void ReceiveHeal(float Heal)
    {
        if (Current < _max)
            Current += Heal;

        if (Current > _max)
            Current = _max;

        HealthChanged?.Invoke(Current, _max);

        Debug.Log($"Здоровье {_name}: {Current}");
    }
}
