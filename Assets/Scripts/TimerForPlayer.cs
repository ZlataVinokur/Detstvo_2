using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class TimerForPlayer : MonoBehaviour
{
    public TextMeshProUGUI _textUGUI;
    [SerializeField] public float _timerFP;
    private float _timerValue;
    private float _timerOutput;
    private int _timerOutputInt;
    private Player _player;
    private Tower _tower;

    void Start()
    {
        GetComponent<TMP_Text>().text = "время искать ресурсы";
        _player = FindObjectOfType<Player>();
        _tower = FindObjectOfType<Tower>();
       
    }

    void Update()
    {
        _timerValue+=Time.deltaTime;
        if (_timerValue >= _timerFP)
        {
            _timerOutput+=Time.deltaTime;
            _timerOutputInt = 180 - (int)_timerOutput;
            GetComponent<TMP_Text>().text = _timerOutputInt.ToString() + " сек осталось оборонять площадку";

            if (_timerOutputInt == 0 && _player._health>0 && _tower._healthT>0)
            {
                OpenWin();
            }
        }
    }

    private void OpenWin()
    {
        SceneManager.LoadScene("win");
    }

}
