using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public PlayerManager playerMnagaerETC;
    public PlayerMovementETC playerMovement;
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
    public IEnumerator WaitToFinishGame()
    {

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("BetterMainMenu"); // loads the main menu scene

    }


    public void RdeanTimer(float timernumber)
    {
        Timer.text = Mathf.RoundToInt(timernumber).ToString();
    }

    public void CheckGameConditions() // a function that checks the conditions of the timer to see when it reaches 0
    {
        if (timernumber <= 0)
        {
            playerMnagaerETC.textBoxA.SetActive(true);
            playerMnagaerETC.textBoxB.SetActive(true);
            playerMnagaerETC.textBoxC.SetActive(true);
            playerMnagaerETC.textBoxD.SetActive(true);
            timernumber = 0;
            playerMnagaerETC.playerFourScoreboard.text = playerMnagaerETC.playerFourScore.ToString(" : " + playerMnagaerETC.playerFourScore);
            playerMnagaerETC.playerThreeScoreboard.text = playerMnagaerETC.playerThreeScore.ToString(" : " + playerMnagaerETC.playerThreeScore);
            playerMnagaerETC.playerTwoScoreboard.text = playerMnagaerETC.playerTwoScore.ToString(" : " + playerMnagaerETC.playerTwoScore);
            playerMnagaerETC.playerOneScoreboard.text = playerMnagaerETC.playerOneScore.ToString(" : " + playerMnagaerETC.playerOneScore);
            Time.timeScale = 0;
           
            Debug.Log("Game Over"); // Debugs out when the timer reaches 0 that the game is over
            StartCoroutine(WaitToFinishGame());
            
            
        }

    }
    
    
}
