using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dost3 : MonoBehaviour
{
    
    
    void Start()
    {
        foreach (Transform child in GetComponentInParent<Transform>())
        {
            GameObject cld = child.gameObject;
            cld.SetActive(false);
        }
    }

    public void Dost1Activation()
    {
        foreach (Transform child in GetComponentInParent<Transform>())
        {
            GameObject cld = child.gameObject;
            cld.SetActive(true);
        }
    }
}
