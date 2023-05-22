using Pathfinding;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAII : MonoBehaviour
{
    [SerializeField] private float _minWalkableDistance;
    [SerializeField] private float _maxWalkableDistance;
    [SerializeField] private float _reachedPointDistance;
    [SerializeField] private GameObject _roamTarget;
    
    [SerializeField] private float _targetFollowRange; 
    [SerializeField] private EnemyAttack _enemyAttack;
    [SerializeField] private float _stopTargetFollowingRange;
    [SerializeField] private AIDestinationSetter _aiDestinationSetter;
    [SerializeField] private EnemyAnimator _enemyAnimator;
    [SerializeField] private AIPath aiPath;

    private Player _player;
    private Tower _tower;
    private EnemyStates _currentState;
    private Vector3 _roamPosition;
    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _tower = FindObjectOfType<Tower>();
        _currentState = EnemyStates.Roaming;
        _roamPosition = GenerateRoamPosition();
    }
    private void Update()
    {
        switch (_currentState)
        {
            case EnemyStates.Roaming:
                _roamTarget.transform.position = _roamPosition;
                if (Vector3.Distance(gameObject.transform.position, _roamPosition) <= _reachedPointDistance)
                {
                    _roamPosition = GenerateRoamPosition();
                }
                _aiDestinationSetter.target = _roamTarget.transform;

                if (Vector3.Distance(gameObject.transform.position, _tower.transform.position) < Vector3.Distance(gameObject.transform.position, _player.transform.position))
                {
                    TryFindTower();
                    _enemyAnimator.IsWalking(true);
                    _enemyAnimator.IsRunning(false);
                    aiPath.maxSpeed = 2;
                }

                else 
                {
                    TryFindPlayer();
                    _enemyAnimator.IsWalking(true);
                    _enemyAnimator.IsRunning(false);
                    aiPath.maxSpeed = 2;
                }

                break;


            case EnemyStates.Following:
                _aiDestinationSetter.target = _player.transform;

                _enemyAnimator.IsWalking(false);
                _enemyAnimator.IsRunning(true);

                aiPath.maxSpeed = 4;

                if (Vector3.Distance(gameObject.transform.position, _player.transform.position) < _enemyAttack.AttackRange)
                {

                    _enemyAnimator.IsWalking(false);
                    _enemyAnimator.IsRunning(false);

                    if (_enemyAttack.CanAttack)
                    {
       
                        _enemyAttack.TryAttackPlayer();
                        _enemyAnimator.PlayAttack();

                    }
                    
                }
                
                if (Vector3.Distance(gameObject.transform.position, _player.transform.position) >= _stopTargetFollowingRange)
                {
                    _currentState = EnemyStates.Roaming;
                }
                break;

            case EnemyStates.FollowingTow:
                _aiDestinationSetter.target = _tower.transform;

                _enemyAnimator.IsWalking(false);
                _enemyAnimator.IsRunning(true);

                aiPath.maxSpeed = 4;

                if (Vector3.Distance(gameObject.transform.position, _tower.transform.position) < _enemyAttack.AttackRange)
                {

                    _enemyAnimator.IsWalking(false);
                    _enemyAnimator.IsRunning(false);

                    if (_enemyAttack.CanAttack)
                    {
                        _enemyAttack.TryAttackTower();
                        _enemyAnimator.PlayAttack();

                    }
                }
                break;
        }
    }
    private void TryFindPlayer()
    {
        if (Vector3.Distance(gameObject.transform.position, _player.transform.position) <= _targetFollowRange)
        {
            _currentState = EnemyStates.Following;
        }
    } 
    private void TryFindTower()
    {
        if (Vector3.Distance(gameObject.transform.position, _tower.transform.position) <= _targetFollowRange)
        {
            _currentState = EnemyStates.FollowingTow;
        }
    }


    private Vector3 GenerateRoamPosition()
    {
        var roamPosition = gameObject.transform.position + GenerateRandomDirection() * GenerateRandomWalkableDistance();
        return roamPosition;
    }
    private float GenerateRandomWalkableDistance()
    {
        var randomDistance = Random.Range(_minWalkableDistance, _maxWalkableDistance);
        return randomDistance;
    }
    private Vector3 GenerateRandomDirection()
    {
        var newDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        return newDirection.normalized;
    }
}
public enum EnemyStates
{
    Roaming,
    FollowingTow,
    Following
}