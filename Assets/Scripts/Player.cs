using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{

    [SerializeField] public int _health;

    public void TakeDamage(int damage)
    {

        _health -= damage;

        if (_health - damage<=0)
        {
            OpenDeath();
        }

    }

    public void TakeFood(int heal)
    {
        if (_health + heal <= 15)
        {
            _health+=heal;
            
        }
        else { _health = 15; }
    }

    private void OpenDeath()
    {
        SceneManager.LoadScene("death");
    }

}
