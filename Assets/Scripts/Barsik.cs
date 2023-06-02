using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barsik : MonoBehaviour
{
    private Dost3 _dost3;
    private void Start()
    {
        _dost3 = FindObjectOfType<Dost3>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            _dost3.Dost3Activation();
        }

    }
}
