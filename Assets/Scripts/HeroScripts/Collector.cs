using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Collector : MonoBehaviour
{
    [SerializeField] private CoinPool _coinPool;

    public event Action<Coin> GetCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin _coin))
        {
            GetCoin?.Invoke(_coin);
            _coinPool.ReturnCoin(_coin);
        }
    }
}
                                                                            