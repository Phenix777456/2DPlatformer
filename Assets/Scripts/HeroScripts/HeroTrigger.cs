using UnityEngine;

public class HeroTrigger : MonoBehaviour
{
    [SerializeField] private StrikeHandler _strikeHandler;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            if (enemy.gameObject.TryGetComponent<HealthHendler>(out HealthHendler healthHendler) && _strikeHandler.isAttacking == true)
                healthHendler.TakeDamage();
    }
}
