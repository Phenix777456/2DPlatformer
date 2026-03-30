using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _secondTargetTransform;
    [SerializeField] private Transform _firstTargetTransform;
    [SerializeField] private ZoneTriger _zoneTriger;
    [SerializeField] private Patroler _moveToTarget;
    [SerializeField] private Mover _mover;

    private bool _isFindTarget;
    private Transform _finalTarget;
    private Transform _heroTarget;

    [field: SerializeField] public Health Health { get; private set; }

    private void Awake()
    {
        Health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _zoneTriger.EnteringZone += OnFindTarget;
        Health.Exhausted += OnHealthExhausted;
    }

    private void Start()
    {
        _isFindTarget = false;
        _finalTarget = _firstTargetTransform;
    }

    private void Update()
    {
        HandleCondition();
    }

    private void OnDisable()
    {
        _zoneTriger.EnteringZone -= OnFindTarget;
        Health.Exhausted -= OnHealthExhausted;
    }
    public void FindTarget()
    {
        _isFindTarget = true; 
    }

    public void LoseTarget()
    {
        _isFindTarget = false;
        _finalTarget = _firstTargetTransform;
    }

    private void OnHealthExhausted()
    {
        gameObject.SetActive(false);
    }

    private void OnFindTarget(Transform target)
    {
        _heroTarget = target;
    }

    private void HandleCondition()
    {
        float step = _speed * Time.deltaTime;

        if (_isFindTarget == false)
        {
            _finalTarget = _moveToTarget.CalculateBasicMovement(_firstTargetTransform, _secondTargetTransform, _finalTarget);

            _mover.Move(_finalTarget, step);
        }

        if (_isFindTarget == true)
        {
            _moveToTarget.TurnAround(_heroTarget);

            _mover.Move(_heroTarget, step);
        }
    }

}
