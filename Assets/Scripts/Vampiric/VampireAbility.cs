using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Hero))]
public class VampireAbility : MonoBehaviour
{
    [SerializeField] private VampireTrigger _vampireTrigger;
    [SerializeField] private float _vampireValue;
    [SerializeField] private int _timer;
    [SerializeField] private int _cooldownTimer;

    private List<Enemy> _enemies;
    private Hero _hero;
    private bool _isReady = true;

    public event Action<float> AbilityProgressChanged;   
    public event Action<float> CooldownProgressChanged;  
    public event Action AbilityStarted;
    public event Action AbilityEnded;
    public event Action CooldownEnded;

    private void OnEnable()
    {
        _enemies = new List<Enemy>();
        _hero = GetComponent<Hero>();
        _vampireTrigger.EnamyAttaced += OnEnemyAttached;
        _vampireTrigger.EnemyLosted += OnEnemyLosted;
    }

    private void OnDisable()
    {
        _vampireTrigger.EnamyAttaced -= OnEnemyAttached;
        _vampireTrigger.EnemyLosted -= OnEnemyLosted;
    }

    public void TryActivate()
    {
        if (_isReady)
            StartCoroutine(ActivateAbility());
    }

    private void OnEnemyAttached(Enemy enemy)
    {
        _enemies.Add(enemy);
    }

    private void OnEnemyLosted(Enemy enemy)
    {
        _enemies.Remove(enemy);
    }

    private IEnumerator ActivateAbility()
    {
        _isReady = false;
        AbilityStarted?.Invoke();

        float elapsed = 0f;
        WaitForEndOfFrame frame = new WaitForEndOfFrame();

        while (elapsed < _timer)
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i] != null && _hero.Health.Current != _hero.Health.Max)
                {
                    _enemies[i].Health.Reduce(_vampireValue);
                    _hero.Health.ReceiveHeal(_vampireValue);
                }
            }

            yield return frame;

            elapsed += Time.deltaTime;

            AbilityProgressChanged?.Invoke(1f - elapsed / _timer);
        }

        AbilityEnded?.Invoke();
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        float elapsed = 0f;
        WaitForEndOfFrame frame = new WaitForEndOfFrame();

        while (elapsed < _cooldownTimer)
        {
            elapsed += Time.deltaTime;
            CooldownProgressChanged?.Invoke(elapsed / _cooldownTimer);
            yield return frame;
        }

        _isReady = true;
        CooldownEnded?.Invoke();
    }
}