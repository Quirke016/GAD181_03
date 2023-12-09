using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEditor.Experimental.GraphView;

public class PlayerManager : MonoBehaviour
{
    public int playerOneScore; // int that displays players score
    public int playerTwoScore; // int that displays players score
    public int playerThreeScore; // int that displays players score
    public int playerFourScore; // int that displays players score

    public bool playerCanScore; // bool to see if players are able to score

    public TextMeshProUGUI playerOnePoints; // text mesh for players score
    public TextMeshProUGUI playerTwoPoints; // text mesh for players score
    public TextMeshProUGUI playerThreePoints; // text mesh for players score
    public TextMeshProUGUI playerFourPoints; // text mesh for players score
    public TextMeshProUGUI playerOneScoreboard; // text mesh that displayers players score at end of game
    public TextMeshProUGUI playerTwoScoreboard; // text mesh that displayers players score at end of game
    public TextMeshProUGUI playerThreeScoreboard; // text mesh that displayers players score at end of game
    public TextMeshProUGUI playerFourScoreboard; // text mesh that displayers players score at end of game

    public GameObject textBoxA; // public gameobject to turn player score off at start of game and on at end screen
    public GameObject textBoxB; // public gameobject to turn player score off at start of game and on at end screen
    public GameObject textBoxC; // public gameobject to turn player score off at start of game and on at end screen
    public GameObject textBoxD; // public gameobject to turn player score off at start of game and on at end screen

    public GameObject buttonMenu; // main menu button


    public bool displayScore; // bool that is used to know when to display the scoreboard
    
   
   

    // Start is called before the first frame update
    void Start()
    {
        displayScore = false; // sets displayscore to false when game starts
        playerOneScore = 0; // sets player score to 0 when game starts
        playerTwoScore = 0; // sets player score to 0 when game starts
        playerThreeScore = 0; // sets player score to 0 when game starts
        playerFourScore = 0; // sets player score to 0 when game starts
        textBoxA.SetActive(false); // sets player scoreboard to false when game starts
        textBoxB.SetActive(false); // sets player scoreboard to false when game starts
        textBoxC.SetActive(false); // sets player scoreboard to false when game starts
        textBoxD.SetActive(false); // sets player scoreboard to false when game starts
        buttonMenu.SetActive(false); // sets button appearance to false when game starts
        playerCanScore = true; // enables the player to score

    }

    // Update is called once per frame
    void Update()
    {

        PlayerScoringSystem(); // calls the scoring system function
        DisplayScoreBoard(); // calls the scoreboard system function
     
    }
    public void SetDisplaceScore(bool displaceScore) // function that takes in a bool and sets the display score bool to true or false
    {
        displayScore = displaceScore; // sets the value of display score to that of displace score
    }
    void PlayerScoringSystem() // player scoring function that displays the players score at the top of the screen as well as adds to their score when their button is pressed
    {
        playerOnePoints.SetText("Player One (S): " + playerOneScore.ToString()); // converts player score to string and displays their score in real time
        playerTwoPoints.SetText("Player Two (K): " + playerTwoScore.ToString()); // converts player score to string and displays their score in real time
        playerThreePoints.SetText("Player Three (DownArrow): " + playerThreeScore.ToString()); // converts player score to string and displays their score in real time
        playerFourPoints.SetText("Player Four (F): " + playerFourScore.ToString()); // converts player score to string and displays their score in real time


        if (Input.GetKeyDown(KeyCode.S) && playerCanScore == true) // checks to see if player scoring is enabled and the assigned player button is pressed
        {
            Debug.Log("Player One is scoring!"); // debugs that the player is scoring
            playerOneScore++; // adds to the players score when button is pressed
        }

        if (Input.GetKeyDown(KeyCode.K) && playerCanScore == true) // checks to see if player scoring is enabled and the assigned player button is pressed
        {
            Debug.Log("Player Two is scoring!"); // debugs that the player is scoring
            playerTwoScore++; // adds to the players score when button is pressed
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && playerCanScore == true) // checks to see if player scoring is enabled and the assigned player button is pressed
        {
            Debug.Log("Player Three is scoring!"); // debugs that the player is scoring
            playerThreeScore++; // adds to the players score when button is pressed
        }
        if (Input.GetKeyDown(KeyCode.F) && playerCanScore == true) // checks to see if player scoring is enabled and the assigned player button is pressed
        {
            Debug.Log("Player Four is scoring!"); // debugs that the player is scoring
            playerFourScore++; // adds to the players score when button is pressed
        }
    }

    void DisplayScoreBoard() //  display scoreboard function that when set to true displays player scores at the end of the game
    {
        
        if(displayScore == true)
        {
            playerOneScoreboard.enabled = true;
            playerTwoScoreboard.enabled = true;
            playerThreeScoreboard.enabled = true;
            playerFourScoreboard.enabled = true;
           
        }
    }
  



}
