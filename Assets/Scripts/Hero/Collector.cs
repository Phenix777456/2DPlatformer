using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Collector : MonoBehaviour
{
    [SerializeField] private CoinPool _coinPool;

    public event Action<Coin> CoinIsGeted;
    public event Action<int> HealIsGeted;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            CoinIsGeted?.Invoke(coin);
            _coinPool.ReturnCoin(coin);
        }
        else if(collision.gameObject.TryGetComponent<Heal>(out Heal heal))
        {
            HealIsGeted?.Invoke(heal.ReturnHealPower());
            heal.DestroyHeal();
        }
    }
}
                                                                            