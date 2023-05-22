using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] private int _healthT;

    public void TakeDamage(int damage)
    {
        _healthT -= damage;

        if (_healthT - damage <= 0)
        {
            Debug.Log("TowerDied");
            return;
        }

    }

}
