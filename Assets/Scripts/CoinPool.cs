using UnityEngine;
using UnityEngine.Pool;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Vector3 _startPosition;

    public ObjectPool<Coin> Coins { get; private set; }

    public int _maxSize { get; private set; }

    private void Awake()
    {
        _maxSize = 5;
    }

    private void Start()
    {
        Coins = new ObjectPool<Coin>(createFunc: () => Instantiate(_coin),
            actionOnGet: ActionOnGet,
            actionOnRelease: ActionOnRelease,
            maxSize: _maxSize);
    }

    private void ActionOnGet(Coin coin)
    {
        coin.gameObject.SetActive(true); 
        coin.gameObject.transform.SetParent(this.gameObject.transform);
        coin.gameObject.transform.position = _startPosition;
        _startPosition += new Vector3(2,0,0);
    }

    private void ActionOnRelease(Coin coin)
    {
        coin.gameObject.SetActive(false);
    }

}
