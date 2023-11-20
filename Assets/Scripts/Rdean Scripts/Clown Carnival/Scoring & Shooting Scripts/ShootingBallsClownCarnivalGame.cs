using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClowncarnivalShooting : MonoBehaviour
{

    public GameObject BallSpawn; // public game object that is used as the spawn location for the ball
    public GameObject BallImage; // public game object that stores the prefab for the ball
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BallSpawnPoint(); // calls the ball spawn function when space is pressed
    }

    public void BallSpawnPoint() // function that spawns in the ball when space bar is pressed at the current position that spacebar is pressed
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Instantiate(BallImage, BallSpawn.transform.position, BallSpawn.transform.rotation);
            Debug.Log("Spacebar has been pressed!"); // debugs out when spacebar is pressed
        }

        
    }
}
