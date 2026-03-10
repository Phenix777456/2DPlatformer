using System;
using UnityEngine;

public class HeroTrigger : MonoBehaviour
{
    public event Action<Coin> IsCoinEarned;

    [SerializeField] private CoinPool CoinPool;

    private Coin _coin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out _coin))
        {
            CoinPool._coins.Release(_coin);

            IsCoinEarned?.Invoke(_coin);
        }
    }
}
