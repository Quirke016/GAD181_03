using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TheFallMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private SpriteRenderer playerRenderer;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float playerX = -3.5f;
    [SerializeField] private float playerY = 1.5f;
    public TheFallGameManager gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
          gameManager = FindObjectOfType<TheFallGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position = new Vector2(playerX, playerY);

        if (gameManager.playersList[0])
        {
            //Movement using the W A S D keys
            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("W pressed");
                PlayerOneMoveUp();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("S pressed");
                PlayerOneMoveDown();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("D pressed");
                PlayerOneMoveRight();
                if (playerRenderer.flipX == true)
                {
                    playerRenderer.flipX = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("A pressed");
                PlayerOneMoveLeft();
                if (playerRenderer.flipX == false)
                {
                    playerRenderer.flipX = true;
                }
            }
        }
        
        //Movement using the arrow keys
        if (gameManager.playersList[0])
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Up pressed");
                PlayerOneMoveUp();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Down pressed");
                PlayerOneMoveDown();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Right pressed");
                PlayerOneMoveRight();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("Left pressed");
                PlayerOneMoveLeft();
            }
        }


    }

    void PlayerOneMoveUp()
    {
        playerY = playerY + moveSpeed;
    }
    void PlayerOneMoveDown()
    {
        playerY = playerY - moveSpeed;
    }

    void PlayerOneMoveRight()
    {
        playerX = playerX + moveSpeed;
    }

    void PlayerOneMoveLeft()
    {
        playerX = playerX - moveSpeed;
    }
}
