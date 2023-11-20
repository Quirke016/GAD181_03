using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TCT_Players : MonoBehaviour
{
    #region Vars
    public int playerOnePoints;
    public int playerTwoPoints;
    public int playerThreePoints;
    public int playerFourPoints;

    public bool playerOneAlive = true;
    public bool playerTwoAlive = true;
    public bool playerThreeAlive = true;
    public bool playerFourAlive = true;

    public TextMeshProUGUI redPoints;
    public TextMeshProUGUI redAlive;
    public TextMeshProUGUI greenPoints;
    public TextMeshProUGUI greenAlive;
    public TextMeshProUGUI bluePoints;
    public TextMeshProUGUI blueAlive;
    public TextMeshProUGUI yellowAlive;
    public TextMeshProUGUI yellowPoints;
    public TextMeshProUGUI timer;

    [SerializeField] bool gameStarted = false;
    [SerializeField] bool gameOver = false;
    [SerializeField] float timeLeft = 45;

    [SerializeField] float gameTimer; 

    #endregion
    void Start()
    {
        playerOnePoints = 0;
        playerTwoPoints = 0;
        playerThreePoints = 0;
        playerFourPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        #region display points and lives
        redPoints.SetText(playerOnePoints.ToString());
        if (!playerOneAlive)
        {
            redAlive.SetText("Red Is Exterminated!");
        }

        greenPoints.SetText(playerTwoPoints.ToString());
        if (!playerTwoAlive)
        {
            greenAlive.SetText("Green Is Exterminated!");
        }

        bluePoints.SetText(playerThreePoints.ToString());
        if (!playerThreeAlive)
        {
            blueAlive.SetText("Blue Is Exterminated!");
        }

        yellowPoints.SetText(playerFourPoints.ToString());
        if (!playerFourAlive)
        {
            yellowAlive.SetText("Yellow Is Exterminated!");
        }
        #endregion

        if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.A) && playerOneAlive)
            {
                playerOnePoints++;
                Debug.Log("P1");
                gameStarted = true;
            }

            if (Input.GetKeyDown(KeyCode.F) && playerTwoAlive)
            {
                playerTwoPoints++;
                Debug.Log("P2");
                gameStarted = true;
            }

            if (Input.GetKeyDown(KeyCode.J) && playerThreeAlive)
            {
                playerThreePoints++;
                Debug.Log("P3");
                gameStarted = true;
            }
            if (Input.GetKeyDown(KeyCode.Semicolon) && playerFourAlive)
            {
                playerFourPoints++;
                Debug.Log("P4");
                gameStarted = true;
            }
        }


        bool playOnce = false;
        if (gameStarted && !playOnce)
        {
            // start animations
                StartCoroutine(CountDown());
            timer.SetText(timeLeft.ToString() + "seconds");
            StartCoroutine(GameStageOne());
            StartCoroutine(GameStageTwo());
            StartCoroutine(GameStageThree());
                playOnce = true;
        }
        if (gameOver)
        {
            Debug.Log("game ended");
            //end screen
        }
    }

    #region IEnumerators
    #region gameStages
    IEnumerator GameStageOne()
    {
        yield return new WaitForSeconds(10);
        if (playerOnePoints < 50)
            playerOneAlive = false;

        if (playerTwoPoints < 50)
            playerTwoAlive = false;

        if (playerThreePoints < 50)
            playerThreeAlive = false;

        if (playerFourPoints < 50)
            playerFourAlive = false;
    } 
    IEnumerator GameStageTwo()
    {
        yield return new WaitForSeconds(25);
        if (playerOnePoints < 95)
            playerOneAlive = false;

        if (playerTwoPoints < 95)
            playerTwoAlive = false;

        if (playerThreePoints < 95)
            playerThreeAlive = false;

        if (playerFourPoints < 95)
            playerFourAlive = false;
    }IEnumerator GameStageThree()
    {
        yield return new WaitForSeconds(38.5f);
        if (playerOnePoints < 170)
            playerOneAlive = false;

        if (playerTwoPoints < 170)
            playerTwoAlive = false;

        if (playerThreePoints < 170)
            playerThreeAlive = false;

        if (playerFourPoints < 170)
            playerFourAlive = false;
    }


    #endregion
    IEnumerator CountDown()
    { 
        yield return new WaitForSeconds(45);
        gameOver = true;
    }
    #endregion
}
