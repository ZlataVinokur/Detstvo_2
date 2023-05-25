using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    [SerializeField] public int _healAmount;
    
    private void OnTriggerEnter(Collider my)
    {
        if (my.tag == "Player")
        {  
            my.GetComponent<Player>().TakeFood(_healAmount);
            Destroy(gameObject);
        }
    }

    
}
