using UnityEngine;

public class HealthHendler : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _baseDamage;
    [SerializeField] private string _name;
    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage()
    {
        _currentHealth -= _baseDamage;
        Debug.Log($"Здоровье {_name}: {_currentHealth}");

        if (_currentHealth <= 0)
            gameObject.SetActive(false);
    }

    public void ReceiveHeal(float Heal)
    {
        if (_currentHealth < _maxHealth)
            _currentHealth += Heal;

        Debug.Log($"Здоровье {_name}: {_currentHealth}");
    }
}
