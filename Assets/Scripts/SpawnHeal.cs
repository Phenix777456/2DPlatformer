using UnityEngine;

public class SpawnHeal : MonoBehaviour
{
    [SerializeField] private int _countOfHeals = 4;
    [SerializeField] private Recovery _healPrefab;
    [SerializeField] private float _rangeX = 10f;

    private void Start()
    {
        for (int i = 0; i < _countOfHeals; i++)
        {
            float randomOffsetX = Random.Range(-_rangeX, _rangeX);
            Vector3 spawnPosition = transform.position + new Vector3(randomOffsetX, 0f, 0f);

            Instantiate(_healPrefab, spawnPosition, Quaternion.identity); 
        }
    }
}