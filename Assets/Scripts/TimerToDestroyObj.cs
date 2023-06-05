using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerToDestroyObj : MonoBehaviour
{
    [SerializeField] public float _timerr;

    private float _timerValue;
    private void Update()
    {
        _timerValue += Time.deltaTime;
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (_timerValue == _timerr && other.tag != "Loot")
        {
            Destroy(gameObject);
        }
        
    }




}
