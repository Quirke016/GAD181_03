using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{

    public TextMeshProUGUI Timer; // public text mesh used to enable the timer on the UI
    public float timernumber; // float that will be used to display the timer in the minigame
    

    // Start is called before the first frame update
    void Start()
    {
        timernumber = 60; // sets the timer of the minigame to 60 seconds
    }

    // Update is called once per frame
    void Update()
    {
        timernumber -= Time.deltaTime; // sets the time to delta time
        Timer.SetText(timernumber.ToString()); // converts the timer text to a string

        CheckGameConditions();
    }


    public void CheckGameConditions() // a function that checks the conditions of the timer to see when it reaches 0
    {
        if (timernumber == 0)
        {
            Debug.Log("Game Over"); // Debugs out when the timer reaches 0 that the game is over
        }
    }
}
