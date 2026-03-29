using System;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Collector _collector;

    private void OnEnable()
    {
        _health.HealthExhausted += OnHealthExhausted;
        _collector.HealIsGeted += OnHealGeted;
    }

    private void OnDisable()
    {
        _health.HealthExhausted -= OnHealthExhausted;
        _collector.HealIsGeted -= OnHealGeted;
    }

    private void OnHealthExhausted()
    {
        gameObject.SetActive(false);
    }

    private void OnHealGeted(int healPower)
    {
        _health.ReceiveHeal(healPower);
    }
}
