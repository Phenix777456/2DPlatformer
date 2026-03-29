using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Hero>(out Hero hero))
            if (hero.gameObject.TryGetComponent<HealthHendler>(out HealthHendler healthHendler))
                healthHendler.TakeDamage();
    }
}
