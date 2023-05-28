using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LootScript : MonoBehaviour
{
    [SerializeField] public int _lootAmount = 0;
    [SerializeField] public int _krapAmount = 0;
    

    private Invisible _invisible;
    private Destroy_krap _destroyKrap;
    private Dost1 _dost1;
    private Dost2 _dost2;

    private void Start()
    {
        _invisible = FindObjectOfType<Invisible>();
        _destroyKrap = FindObjectOfType<Destroy_krap>();
        _dost1 = FindObjectOfType<Dost1>();
        _dost2 = FindObjectOfType<Dost2>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food" || other.tag == "Weapon" || other.tag == "Krapiva")
        {
            _lootAmount += 1;

            if (other.tag == "Krapiva")
            {
                _krapAmount += 1;

                if (_krapAmount == 3)
                {
                    _invisible.Visible();
                    _dost1.Dost1Activation();
                    _destroyKrap.DestroyKrap();
                    
                }

            }

            if (_lootAmount == 9)
            {
                _dost2.Dost2Activation();
            }
            
        }

    }
}
