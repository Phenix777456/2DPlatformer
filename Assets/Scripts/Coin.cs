using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> IsCoinErned;

    public void CoinRealised(Coin coin)
    {
        IsCoinErned?.Invoke(coin);
    }
}
