using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{

    public void StartBtn()
    {
        SceneManager.LoadScene("menu");
    }
}
