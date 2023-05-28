using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour
{
    [Header("Unity Setup")]
    public ParticleSystem eliteKrapParticles;
    Renderer test;

    void Start()
    {
        test = GetComponent<MeshRenderer>();
        test.enabled = false;
    }
    public void Visible()
    {
        test = GetComponent<MeshRenderer>();
        test.enabled = true;
        Instantiate(eliteKrapParticles, transform.position, Quaternion.identity);
    }
}
