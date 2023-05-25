using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _healthEnemy;

    public void TakeDamage(int damage)
    {

        _healthEnemy -= damage;

        if (_healthEnemy - damage <= 0)
        {
            Debug.Log("Enemy_Died");
            return;
        }

    }
}
