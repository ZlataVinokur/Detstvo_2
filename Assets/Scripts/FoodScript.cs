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
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Healing);

    }

    public void Healing(ActivateEventArgs arg)
    {
        if (_player._health > 0 && _player._health < 15)
        {
            _player.TakeFood(_healthAmount);
            Destroy(this.gameObject);
        }
    }
}
