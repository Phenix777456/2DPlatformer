using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] private Collector _collector;

    private List<Coin> _coins;

    private void Awake()
    {
        _coins = new List<Coin>();
        _collector.CoinIsGeted += OnGetCoin;
    }

    private void OnGetCoin(Coin coin)
    {
        _coins.Add(coin);
        Debug.Log("Монет собранно:" + _coins.Count);
    }

    private void OnDisable()
    {
        _collector.CoinIsGeted -= OnGetCoin;
    }
}
