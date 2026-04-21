using System;
using UnityEngine;


public class VampireTrigger : MonoBehaviour
{
    public event Action<Enemy> EnamyAttaced;
    public event Action<Enemy> EnemyLosted;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            EnamyAttaced?.Invoke(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            EnemyLosted?.Invoke(enemy);
        }
    }
}
