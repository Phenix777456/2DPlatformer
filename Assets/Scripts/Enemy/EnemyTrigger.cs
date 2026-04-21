using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private float _enemyDamage = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Hero>(out Hero hero))
        {
            hero.TryGetComponent<StrikeHandler>(out StrikeHandler strikeHandler);

            if (strikeHandler.IsAttacking == false)
            {
                hero.Health.Reduce(_enemyDamage);
            }
        }
    }
}
