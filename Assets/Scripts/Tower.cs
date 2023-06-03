using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour
{

    [SerializeField] public int _healthT;

    public void TakeDamage(int damage)
    {
        _healthT -= damage;

        if (_healthT - damage <= 0)
        {
            OpenDeath();
        }

    }

    private void OpenDeath()
    {
        SceneManager.LoadScene("death");
    }

}
