using System;
using UnityEngine;
using UnityEngine.Pool;

public class HeroTrigger : MonoBehaviour
{
    public event Action<Coin> CoinEarned;

    [SerializeField] private CoinPool _coinPool;

    private Coin _coin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ObjectPool<Coin> _pool = _coinPool.Coins;

        if (collision.gameObject.TryGetComponent<Coin>(out _coin))
        {
            _pool.Release(_coin);

            CoinEarned?.Invoke(_coin);
        }
    }
}
