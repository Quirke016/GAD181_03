using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFallPlatform : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;
    [SerializeField] private bool active = false;
    [SerializeField] private bool destroy = false;
    [SerializeField] private bool killState = false;
    [SerializeField] private float gameTimer;
    [SerializeField] private float timer;
    [SerializeField] private float playerIdleTimer;
    public float interval;
    public SpriteRenderer tf_spriteRenderer;
    public TheFallGameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //if the platform does not have a reference to its own renderer, get the reference
        if (tf_spriteRenderer == null)
        {
            tf_spriteRenderer = GetComponent<SpriteRenderer>();
        }

        //if the platform does not have a reference to the game manager, get the reference
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<TheFallGameManager>();
        }

        //the player idle timer is set to the initial timer life
        playerIdleTimer = gameManager.platformLife[0];

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //The platforms is acrivated and begins the destruction sequence. 
        //the destroy is to prevent the platform from being active again and resetting when it is triggered
        if(destroy == false)
        {
            active = true;
        }
        

        //every time the player enters a new platform the idle timer is reset
        gameManager.playerIdle = playerIdleTimer;
        if (killState == true)
        {
            Destroy(gameManager.playersList[0]);
        }
    }


    // Update is called once per frame
    void Update()
    {
        //The intervals for the platforms is set and is edited through the game manager
        interval = gameManager.platformInterval;

        gameTimer = Time.time;

        //The idle time and platform life are updated after every interval is passed (numbers are lowered as the game progresses)
        if (gameTimer < interval)
        {
            playerIdleTimer = gameManager.platformLife[0];
            timeToDestroy = gameManager.platformLife[0];
        }

        if (gameTimer > interval && gameTimer < (interval + interval))
        {
            playerIdleTimer = gameManager.platformLife[1];
            timeToDestroy = gameManager.platformLife[1];
        }

        if (gameTimer > interval + interval && gameTimer < interval + interval + interval)
        {
            playerIdleTimer = gameManager.platformLife[2];
            timeToDestroy = gameManager.platformLife[2];
        }

        if (gameTimer > interval + interval + interval)
        {
            playerIdleTimer = gameManager.platformLife[3];
            timeToDestroy = gameManager.platformLife[3];
        }

        //When the platform is stepped on it begins a timer until it is destroyed
        if (active == true)
        {
            timer = gameTimer + timeToDestroy;
            active = false;
            destroy = true;
            //between being activated and destroyed the platform is set to yellow
            tf_spriteRenderer.color = Color.yellow;
        }

        //once the platform is properly destroyed it is set to kill the player and is made red
        if (destroy == true)
        {
            if (gameTimer >= timer)
            {
                tf_spriteRenderer.color = Color.red;
                killState = true;
            }
        }


    }
}

