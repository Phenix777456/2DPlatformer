using UnityEngine;
using UnityEngine.Rendering;

public class MoveBasic : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _secondTargetTransform;
    [SerializeField] private Transform _firstTargetTransform;
    [SerializeField] private ZoneTriger _zoneTriger;
    [SerializeField] private EnemyBasicMovement _enemyBasicMovement;

    private bool _isFindTarget;
    private Transform _finalTarget;
    private Transform _heroTarget;

    private void OnEnable()
    {
        _zoneTriger.EnteringZone += OnFindTarget;
    }

    private void Start()
    {
        _isFindTarget = false;
        _finalTarget = _firstTargetTransform;
    }

    void Update()
    {
        HandleCondition();
    }

    private void OnDisable()
    {
        _zoneTriger.EnteringZone -= OnFindTarget;
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
            _finalTarget = _enemyBasicMovement.CalculateBasicMovement(_firstTargetTransform, _secondTargetTransform, _finalTarget);

            Move(_finalTarget, step);
        }

        if (_isFindTarget == true)
        {
            _enemyBasicMovement.TurnAround(_heroTarget);

            Move(_heroTarget, step);
        }

        Debug.Log(_heroTarget);
    }

    private void Move(Transform targetTransform, float step)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, step);
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
}
