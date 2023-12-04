using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{

    


    public void OnButtonPress()
    {
        Time.timeScale = 1;
         SceneManager.LoadScene("BetterMainMenu"); // loads the main menu scene
    }
}
