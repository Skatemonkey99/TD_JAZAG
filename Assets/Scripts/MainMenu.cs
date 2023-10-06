using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Menu");
    }

    public void StartGame()
    {
        GameManager.Instance.LoadNextScene();
        StatManager.Instance.StartTimer();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
