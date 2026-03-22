using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinPool _coinPool;

    private void Start()
    {
        SpawnCoin(_coinPool.MaxSize);
    }

    private void SpawnCoin(int maxCoinCount)
    {
        for(int i = 0; i < maxCoinCount; i++)
        {
            _coinPool.TrySpawn();
        }
    }
}
