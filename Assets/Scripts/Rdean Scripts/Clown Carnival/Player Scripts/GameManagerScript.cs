using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{

    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver() // game over function that sets the game over UI to true when called
    {
        gameOverUI.SetActive(true);
    }

    public void Restart() // restart function that obtains the added scene, used when the player presses the restart button
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
