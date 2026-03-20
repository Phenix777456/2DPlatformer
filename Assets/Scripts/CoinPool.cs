using UnityEngine;
using UnityEngine.Pool;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Vector3 _startPosition;

    private ObjectPool<Coin> _сoins;

    public int MaxSize { get; private set; }

    private void Awake()
    {
        MaxSize = 5;
    }

    private void Start()
    {
        _сoins = new ObjectPool<Coin>(createFunc: () => Instantiate(_coin),
            actionOnGet: GetCoin,
            actionOnRelease: ReleaseCoin,
            maxSize: MaxSize);
    }

    private void GetCoin(Coin coin)
    {
        coin.IsCoinErned += OnEarnCoin;
        coin.gameObject.SetActive(true); 
        coin.gameObject.transform.SetParent(this.gameObject.transform);
        coin.gameObject.transform.position = _startPosition;
        _startPosition += new Vector3(2,0,0);
        
    }

    private void ReleaseCoin(Coin coin)
    {
        coin.gameObject.SetActive(false);
    }

    private void OnEarnCoin(Coin coin)
    {
        _сoins.Release(coin);
    }

    public ObjectPool<Coin> ReturnPool()
    {
        return _сoins;
    }
}
