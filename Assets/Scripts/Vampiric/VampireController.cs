using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Hero))]
public class VampireController : MonoBehaviour
{
    [SerializeField] private VampireTrigger _vampireTrigger;
    [SerializeField] private float vampireValue;
    [SerializeField] private int _timer;
    [SerializeField] private int _coldownTimer;
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _buttonLabel;

    private List<Enemy> _enemyes;

    private Enemy _enemy;

    private Hero _hero;

    private bool _isReady = true;

    private void Awake()
    {
        _enemyes = new List<Enemy>();
        _hero = GetComponent<Hero>();
        _vampireTrigger.EnamyAttaced += OnEnemyAttaced;
        _vampireTrigger.EnemyLosted += OnEnemyLosted;
        _button.onClick.AddListener(OnClick);
    }
   

    private void OnDisable()
    {
        _vampireTrigger.EnamyAttaced -= OnEnemyAttaced;
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnEnemyAttaced(Enemy enemy)
    {
        _enemyes.Add(enemy);
        Debug.Log(_enemyes.Count);
    }

    private void OnEnemyLosted(Enemy enemy)
    {
       _enemyes.Remove(enemy);
    }

    private void OnClick()
    {
        if (_isReady) 
            StartCoroutine(CalculateVampireTimer(_timer, _enemyes));
    }

    private IEnumerator CalculateVampireTimer(float timer, List<Enemy> enemy)
    {
        _buttonLabel.text = "In process";
        float elapsed = 0f;
        float tickInterval = timer / 10;
        WaitForSeconds finalTimer = new WaitForSeconds(tickInterval);

        while (elapsed < timer)
        {
            for (int i = 0; i < enemy.Count; i++)
            {
                if (enemy[i] != null && (_hero.Health.Current != _hero.Health.Max))
                {
                    enemy[i].Health.Reduce(vampireValue);
                    _hero.Health.ReceiveHeal(vampireValue);
                }
            }

            yield return finalTimer;

            elapsed += tickInterval;
        }

        _isReady = false;

        StartCoroutine(WaitForReload(_coldownTimer));
    }

    private IEnumerator WaitForReload(float trimer)
    {
        
        WaitForSeconds ColdownTimer = new WaitForSeconds(trimer);

        _buttonLabel.text = "Reloading";
        yield return ColdownTimer;
        _buttonLabel.text = "Ready";
        _isReady = true;
    }
}
