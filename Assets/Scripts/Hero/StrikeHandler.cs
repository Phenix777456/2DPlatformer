using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class StrikeHandler : MonoBehaviour
{
    private const string Attack1 = nameof(Attack1);

    [SerializeField] private float _timeStep = 1f;
    [SerializeField] private float _width;
    [SerializeField] private float _height;
    [SerializeField] private float _baseWidth;
    [SerializeField] private float _baseHeight;
    [SerializeField] private AttackInput _attackInput;

    private Coroutine _strikeRoutine;
    private BoxCollider2D _box;

    public bool IsAttacking { get; private set; } = false;

    private void Awake()
    {
        _box = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        if (_attackInput != null)
            _attackInput.AttackButtonIsPressed += HandleAttackPressed;
    }

    private void OnDisable()
    {
        if (_attackInput != null)
            _attackInput.AttackButtonIsPressed -= HandleAttackPressed;
    }

    public void Strike()
    {
        if (_strikeRoutine != null)
            StopCoroutine(_strikeRoutine);

        _strikeRoutine = StartCoroutine(AttackTiming());
    }

    private void HandleAttackPressed()
    {
        Strike();
    }

    private IEnumerator AttackTiming()
    {
        _box.size = new Vector2(_width, _height);
        IsAttacking = true;

        yield return new WaitForSeconds(_timeStep);

        _box.size = new Vector2(_baseWidth, _baseHeight);
        IsAttacking = false;
    }
}
