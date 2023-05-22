using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private int _damage;
    [SerializeField] private float _coolDown;

    private float _timer;

    public bool CanAttack { get; private set; }

    private Player _player;
    private Tower _tower;
    public float AttackRange => _attackRange;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _tower = FindObjectOfType<Tower>();
    }

    private void Update()
    {
        UpdateCooldown();
    }

    private void UpdateCooldown()
    {
        if(CanAttack)
        {
            return;
        }

        _timer += Time.deltaTime;

        if(_timer <= _coolDown)
        {
            return;
        }

        CanAttack = true;

        _timer = 0;
    }
    public void TryAttackPlayer()
    {
        _player.TakeDamage(_damage);

        CanAttack = false;
    }
    public void TryAttackTower()
    {
        _tower.TakeDamage(_damage);

        CanAttack = false;
    }
}


