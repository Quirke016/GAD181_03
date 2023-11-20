using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawPlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private SpriteRenderer playerRenderer;
    [SerializeField] private float moveSpeed = 0.01f;
    [SerializeField] private float playerX = -3.5f;
    [SerializeField] private float playerY = 1.5f;
    public ClawGameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<ClawGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position = new Vector2(playerX, playerY);

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W pressed");
            PlayerOneMoveUp();
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S pressed");
            PlayerOneMoveDown();
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D pressed");
            PlayerOneMoveRight();
            if (playerRenderer.flipX == true)
            {
                playerRenderer.flipX = false;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A pressed");
            PlayerOneMoveLeft();
            if (playerRenderer.flipX == false)
            {
                playerRenderer.flipX = true;
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
