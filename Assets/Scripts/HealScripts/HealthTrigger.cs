using System;
using UnityEngine;

public class HealthTrigger : MonoBehaviour
{
    [SerializeField] private int _healPower = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Hero>(out Hero hero))
        {
            if (hero.gameObject.TryGetComponent<HealthHendler>(out HealthHendler healthHendler))
                healthHendler.ReceiveHeal(_healPower);

            gameObject.SetActive(false);
        }
    }
}
