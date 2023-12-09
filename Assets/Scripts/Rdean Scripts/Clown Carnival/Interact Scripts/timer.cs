using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public PlayerManager playerMnagaerETC; // reference to the player manager script
    public PlayerMovementETC playerMovement; // reference to the player movement script
    public TextMeshProUGUI Timer; // public text mesh used to enable the timer on the UI
    

    public float timernumber; // float that will be used to display the timer in the minigame
    

  

    // Update is called once per frame
    void Update()
    {
        timernumber -= Time.deltaTime; // sets the time to delta time
                                       // converts the timer text to a string
        RdeanTimer(timernumber);
        CheckGameConditions();
        
        
        
    }
    public IEnumerator WaitToFinishGame() // a function that adds 5 seconds once the game ends to display the scoreboard and the scores of the players
    {

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("BetterMainMenu"); // loads the main menu scene

    }


    public void RdeanTimer(float timernumber) // a function for the timer that will be used in game, the value of the timer can be set in the inspector
    {
        Timer.text = Mathf.RoundToInt(timernumber).ToString();
    }

    public void CheckGameConditions() // a function that checks the conditions of the timer to see when it reaches 0
    {
        if (timernumber <= 0)
        {
            playerMnagaerETC.textBoxA.SetActive(true); // sets player scoreboard to be active when timer runs out
            playerMnagaerETC.textBoxB.SetActive(true); // sets player scoreboard to be active when timer runs out
            playerMnagaerETC.textBoxC.SetActive(true); // sets player scoreboard to be active when timer runs out
            playerMnagaerETC.textBoxD.SetActive(true); // sets player scoreboard to be active when timer runs out
            playerMnagaerETC.playerCanScore = false; //disables players from scoring
            playerMnagaerETC.buttonMenu.SetActive(true); // enables the main menu button
            timernumber = 0; // sets the timer number to 0 so that it doesnt go into negative values during the 5 second after game window
            playerMnagaerETC.playerFourScoreboard.text = playerMnagaerETC.playerFourScore.ToString(" : " + playerMnagaerETC.playerFourScore); // displayers the players ending score result
            playerMnagaerETC.playerThreeScoreboard.text = playerMnagaerETC.playerThreeScore.ToString(" : " + playerMnagaerETC.playerThreeScore); // displayers the players ending score result
            playerMnagaerETC.playerTwoScoreboard.text = playerMnagaerETC.playerTwoScore.ToString(" : " + playerMnagaerETC.playerTwoScore); // displayers the players ending score result
            playerMnagaerETC.playerOneScoreboard.text = playerMnagaerETC.playerOneScore.ToString(" : " + playerMnagaerETC.playerOneScore); // displayers the players ending score result
            Time.timeScale = 0; // freezes the game and stops players from moving
           
            Debug.Log("Game Over"); // Debugs out when the timer reaches 0 that the game is over
            StartCoroutine(WaitToFinishGame()); // coroutine to call the wait for game to finish function
            
            
        }

    }
    
    
}
