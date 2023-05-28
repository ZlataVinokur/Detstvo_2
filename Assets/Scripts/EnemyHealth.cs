using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _healthEnemy;
    [Header("Unity Setup")]
    public ParticleSystem deathParticles;

    public void TakeDamage(int damage)
    {

        _healthEnemy -= damage;

        if (_healthEnemy - damage <= 0)
        {
            Destroy();
        }

    }
    public void Destroy()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
