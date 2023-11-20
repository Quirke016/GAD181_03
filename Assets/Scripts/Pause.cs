using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseScreen.SetActive(false);
        
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("BetterMainMenu");
    }

    public void EndApplication() 
    { 
        Application.Quit();
    }
}
