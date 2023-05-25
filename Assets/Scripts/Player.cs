using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private int _health;

    public void TakeDamage(int damage)
    {

        _health -= damage;

        if (_health - damage<=0)
        {
            Debug.Log("Died");
            return;
        }

    }

    public void TakeFood(int heal)
    {
        if (_health == 15)
        {
            Debug.Log("You are good");
            return;
        }
        else if (_health + heal <= 15)
        {
            _health+=heal;
            
        }
        else { _health = 15; }
    }

}
