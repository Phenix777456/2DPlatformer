using UnityEngine;
using UnityEngine.Pool;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Vector3 _startPosition;

    private ObjectPool<Coin> _coins;

    public int MaxSize { get; private set; }

    private void Awake()
    {
        MaxSize = 5;
    }

    private void Start()
    {
        _coins = new ObjectPool<Coin>(createFunc: () => Instantiate(_coin),
            actionOnGet: GetCoin,
            actionOnRelease: ReleaseCoin,
            maxSize: MaxSize);
    }

    private void GetCoin(Coin coin)
    {
        coin.gameObject.SetActive(true); 
        coin.gameObject.transform.SetParent(this.gameObject.transform);
        coin.gameObject.transform.position = _startPosition;
        _startPosition += new Vector3(2,0,0);
        
    }

    private void ReleaseCoin(Coin coin)
    {
        coin.gameObject.SetActive(false);
    }

    public void ReturnCoin(Coin coin)
    {
        _coins.Release(coin);
    }

    public void TrySpawn()
    {
        _coins.Get();  
    }
}
