using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFallGameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public List<GameObject> playersList = new List<GameObject>();
    public List<Vector3> playersPosition = new List<Vector3>();
    public List<float> platformLife = new List<float>();
    public int playersToSpawn;
    public float platformInterval;
    public float playerIdle;
    

    // Start is called before the first frame update
    void Start()
    {
        //Spawns the players using a loop to instantiate the prefabs
        PlayerSpawn();
        playerIdle = platformLife[0];
    }

    // Update is called once per frame
    void Update()
    {
        //If the player idle timer is more than 0 it is reduced overtime
        if (playerIdle > 0)
        {
            playerIdle -= Time.deltaTime;
        }
        else
        {
            //Once the idle timer reaches 0 it destroys the player
            Destroy(playersList[0]);
        }
    }

    private void PlayerSpawn()
    {   
        //Spawns the players, places them into individual locations, adds the players to the list
        if(playerPrefab != null)
        {
            for (int i = 0; i < playersToSpawn; i++)
            {
                GameObject clone = Instantiate(playerPrefab, playersPosition[i], Quaternion.identity);
                playersList.Add(clone);
                Debug.Log("Player" + (i + 1) + " Spawned");
            }
        }

    }
}
