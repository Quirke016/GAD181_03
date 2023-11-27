using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int playerOneScore;
    public int playerTwoScore;

    public TextMeshProUGUI playerOnePoints;
    public TextMeshProUGUI playerTwoPoints;


    // Start is called before the first frame update
    void Start()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
       
       
    }

    // Update is called once per frame
    void Update()
    {
      playerOnePoints.SetText("Player One: " + playerOneScore.ToString());
      playerTwoPoints.SetText("Player Two: " + playerTwoScore.ToString());


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


     if (playerOneScore == 200 && playerTwoScore != 200)
        {
            Debug.Log("Player One has escaped!");
            SceneManager.LoadScene("BetterMainMenu"); // loads the main menu scene 
        }

        if (playerTwoScore == 200 && playerOneScore != 200)
        {
            Debug.Log("Player Two has escaped!");
            SceneManager.LoadScene("BetterMainMenu"); // loads the main menu scene 
        }
    }

    
    




}
