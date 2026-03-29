using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] private Collector _collector;

    private List<Coin> _storageOfCoins;

    private void Awake()
    {
        _storageOfCoins = new List<Coin>();
        _collector.CoinIsGeted += OnGetCoin;
    }

    private void OnGetCoin(Coin coin)
    {
        _storageOfCoins.Add(coin);
        Debug.Log("Монет собранно:" + _storageOfCoins.Count);
    }

    private void OnDisable()
    {
        _collector.CoinIsGeted -= OnGetCoin;
    }
}
