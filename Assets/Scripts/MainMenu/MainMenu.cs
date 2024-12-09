using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene1");
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
