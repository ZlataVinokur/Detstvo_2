using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dost1 : MonoBehaviour
{

    private float _timer = 5;
    private float _timerValue;
    private bool _dostActivated = false;

    void Start()
    {
        foreach (Transform child in GetComponentInParent<Transform>())
        {
            GameObject cld = child.gameObject;
            cld.SetActive(false);
        }
    }


    private void Update()
    {
        if (_dostActivated == true)
        {
            _timerValue += Time.deltaTime;

            if (_timerValue > _timer)
            {
                foreach (Transform child in GetComponentInParent<Transform>())
                {
                    GameObject cld = child.gameObject;
                    cld.SetActive(false);
                }
            }
        }
        
    }

    public void Dost1Activation()
    {
        foreach (Transform child in GetComponentInParent<Transform>())
        {
            GameObject cld = child.gameObject;
            cld.SetActive(true);
            _dostActivated = true;
        }
    }

}
