using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FoodScript : MonoBehaviour
{
    [SerializeField] private int _healthAmount;
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Healing();
        }
    }
    public void Healing()
    {
        if (_player._health > 0 && _player._health < 15)
        {
            _player.TakeFood(_healthAmount);
            Destroy(gameObject);
        }
    }


}
