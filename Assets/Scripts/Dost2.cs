using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dost2 : MonoBehaviour
{
    
    
    void Start()
    {
        foreach (Transform child in GetComponentInParent<Transform>())
        {
            GameObject cld = child.gameObject;
            cld.SetActive(false);
        }
    }

    public void Dost2Activation()
    {
        foreach (Transform child in GetComponentInParent<Transform>())
        {
            GameObject cld = child.gameObject;
            cld.SetActive(true);
        }
    }
}
