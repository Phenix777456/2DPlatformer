using System;
using UnityEngine;
using UnityEngine.Pool;

public class CoinDetector : MonoBehaviour
{
    private Hero _hero;

    private Coin _coin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Hero>(out _hero))
        {
            Debug.Log("++");
            _coin = this.GetComponent<Coin>();
            Debug.Log(_coin);
            _coin.CoinRealised(_coin);
        }
    }
}
