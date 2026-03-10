using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] private HeroTrigger _heroTrigger;

    private List<Coin> _storageOfCoins;

    private void OnEnable()
    {
        _storageOfCoins = new List<Coin>();
        _heroTrigger.IsCoinEarned += OnEarnCoin;
    }

    private void OnEarnCoin(Coin coin)
    {
        _storageOfCoins.Add(coin);
        Debug.Log("Монет собранно:" + _storageOfCoins.Count);
    }

    private void OnDisable()
    {
        _heroTrigger.IsCoinEarned -= OnEarnCoin;
    }
}
