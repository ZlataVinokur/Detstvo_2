using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderSet : MonoBehaviour
{
    [SerializeField] private Slider _sliderVol;
    public static int _volume;

    void Start()
    {
         

        _sliderVol.value = 1f;

    }
    private void Update()
    {
       

        ChangeVol();

    }

    public void ChangeVol()
    {
        AudioListener.volume = _sliderVol.value;
    }
}
