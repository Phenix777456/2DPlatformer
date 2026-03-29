using System;
using UnityEngine;

public class ZoneTriger : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    public event Action<Transform> EnteringZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Hero>(out Hero hero))
        {
            _enemy.FindTarget();
            EnteringZone?.Invoke(collision.gameObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Hero>(out Hero hero))
            _enemy.LoseTarget();
    }
}
