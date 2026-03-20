using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private List<Coin> _storageOfCoins;

    private Coin _coin;

    private void Awake()
    {
        _storageOfCoins = new List<Coin>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out _coin))
        {
            _storageOfCoins.Add(_coin);
            Debug.Log("Монет собранно:" + _storageOfCoins.Count);
        }
    }
}
