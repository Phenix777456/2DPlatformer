using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinPool _coinPool;

    private void Start()
    {
        SpawnCoin(_coinPool._maxSize, _coinPool._coins);
    }

    private void SpawnCoin(int maxCoinCount, ObjectPool<Coin> pool)
    {
        for(int i = 0; i < maxCoinCount; i++)
        {
            pool.Get();
        }
    }
}
