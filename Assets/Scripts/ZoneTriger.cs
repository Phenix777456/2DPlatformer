using System;
using UnityEngine;

public class ZoneTriger : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Hero _hero;

    public event Action<Transform> EnteringZone;

    private EnemyController _moveBasic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Hero>(out _hero))
        {
            _enemy.TryGetComponent<EnemyController>(out _moveBasic);

            if (_moveBasic != null)
            {
                _moveBasic.FindTarget();
                EnteringZone?.Invoke(collision.gameObject.transform);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Hero>(out _hero))
        {
            if (_moveBasic != null)
            {
                _moveBasic.LoseTarget();
            }
        }
    }
}
