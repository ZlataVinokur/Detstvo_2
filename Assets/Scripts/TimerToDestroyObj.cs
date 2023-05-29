using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerToDestroyObj : MonoBehaviour
{
    [SerializeField] public float _timer;
    private int timeToDis = 0;

    private float _timerValue;
    private void Update()
    {
        _timerValue += Time.deltaTime;
        
        if (_timerValue > _timer)
        {
            timeToDis = 1;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (timeToDis==1 && other.tag != "Loot")
        {
            Destroy(gameObject);
        }
        else { Debug.Log("inLoot"); }
    }




}
