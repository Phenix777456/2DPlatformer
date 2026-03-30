using System;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private Collector _collector;
    [field: SerializeField] public Health Health { get; private set; }

    private void Awake()
    {
        Health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        Health.Exhausted += OnHealthExhausted;
        _collector.HealIsGeted += OnHealGeted;
    }

    private void OnDisable()
    {
        Health.Exhausted -= OnHealthExhausted;
        _collector.HealIsGeted -= OnHealGeted;
    }

    private void OnHealthExhausted()
    {
        gameObject.SetActive(false);
    }

    private void OnHealGeted(int healPower)
    {
        Health.ReceiveHeal(healPower);
    }
}
