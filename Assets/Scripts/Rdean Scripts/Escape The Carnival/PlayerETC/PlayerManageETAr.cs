using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEditor.Experimental.GraphView;

public class PlayerManager : MonoBehaviour
{
    public int playerOneScore;
    public int playerTwoScore;
    public int playerThreeScore;
    public int playerFourScore;

    public TextMeshProUGUI playerOnePoints;
    public TextMeshProUGUI playerTwoPoints;
    public TextMeshProUGUI playerThreePoints;
    public TextMeshProUGUI playerFourPoints;
    public TextMeshProUGUI playerOneScoreboard;
    public TextMeshProUGUI playerTwoScoreboard;
    public TextMeshProUGUI playerThreeScoreboard;
    public TextMeshProUGUI playerFourScoreboard;

    public GameObject textBoxA;
    public GameObject textBoxB;
    public GameObject textBoxC;
    public GameObject textBoxD;


    public bool displayScore;
    
   
   

    // Start is called before the first frame update
    void Start()
    {
        displayScore = false;
        playerOneScore = 0;
        playerTwoScore = 0;
        playerThreeScore = 0;
        playerFourScore = 0;
        //playerOneScoreboard.enabled = false;
        //playerTwoScoreboard.enabled = false;
       // playerThreeScoreboard.enabled = false;
       // playerFourScoreboard.enabled = false;
        textBoxA.SetActive(false);
        textBoxB.SetActive(false);
        textBoxC.SetActive(false);
        textBoxD.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        PlayerScoringSystem();
        DisplayScoreBoard();
     
    }
    public void SetDisplaceScore(bool displaceScore)
    {
        displayScore = displaceScore;
    }
    void PlayerScoringSystem()
    {
        playerOnePoints.SetText("Player One: " + playerOneScore.ToString());
        playerTwoPoints.SetText("Player Two: " + playerTwoScore.ToString());
        playerThreePoints.SetText("Player Three: " + playerThreeScore.ToString());
        playerFourPoints.SetText("Player Four: " + playerFourScore.ToString());


        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Player One is scoring!");
            playerOneScore++;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Player Two is scoring!");
            playerTwoScore++;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Player Three is scoring!");
            playerThreeScore++;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Player Four is scoring!");
            playerFourScore++;
        }
    }

    void DisplayScoreBoard()
    {
        
        if(displayScore == true)
        {
            playerOneScoreboard.enabled = true;
            playerTwoScoreboard.enabled = true;
            playerThreeScoreboard.enabled = true;
            playerFourScoreboard.enabled = true;
        }
    }
    /*void PlayerScores()
    {
        if (playerOneScore == 130 && playerTwoScore != 130 && playerThreeScore != 130 && playerFourScore != 130)
        {
            
            Debug.Log("Player One has escaped!");
            
        }

        if (playerTwoScore == 130 && playerOneScore != 130 && playerThreeScore != 130 && playerFourScore != 130)
        {
            
            Debug.Log("Player Two has escaped!");
           
        }

        if (playerThreeScore == 130 && playerOneScore != 130 && playerTwoScore != 130 && playerFourScore != 130)
        {
            
            Debug.Log("Player Three has escaped!");
            
        }

        if (playerFourScore == 130 && playerOneScore != 130 && playerTwoScore != 130 && playerThreeScore != 130)
        {
            
            Debug.Log("Player Four has escaped!");
            

        }
        
    }*/



}
