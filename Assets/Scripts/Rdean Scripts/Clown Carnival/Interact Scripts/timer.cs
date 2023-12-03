using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{

    public TextMeshProUGUI Timer; // public text mesh used to enable the timer on the UI
    public float timernumber; // float that will be used to display the timer in the minigame
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timernumber -= Time.deltaTime; // sets the time to delta time
                                       // converts the timer text to a string
        RdeanTimer(timernumber);
        CheckGameConditions();
        
    }


    public void RdeanTimer(float timernumber)
    {
        Timer.text = Mathf.RoundToInt(timernumber).ToString();
    }

    public void CheckGameConditions() // a function that checks the conditions of the timer to see when it reaches 0
    {
        if (timernumber <= 0)
        {
            SceneManager.LoadScene("BetterMainMenu"); // loads the main menu scene 
            Debug.Log("Game Over"); // Debugs out when the timer reaches 0 that the game is over
            
        }

    }
}
