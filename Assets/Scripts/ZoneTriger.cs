using System;
using UnityEngine;

public class ZoneTriger : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Hero _hero;

    public event Action<Transform> IsEnteringZone;

    private MoveBasic _moveBasic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Hero>(out _hero))
        {
            _enemy.TryGetComponent<MoveBasic>(out _moveBasic);

            if (_moveBasic != null)
            {
                _moveBasic.FindTarget();
                IsEnteringZone?.Invoke(collision.gameObject.transform);
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
