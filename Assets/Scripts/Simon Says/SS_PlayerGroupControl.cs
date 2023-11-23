using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_PlayerGroupControl : MonoBehaviour
{
    public List<GameObject> players = new List<GameObject>();
    public List<SS_PlayerControl> playersBasicConrtols = new List<SS_PlayerControl>();

    public int numberOfPlayers;
    float screenSize;
    public GameObject playerPrefab;
    public bool gameBeging;
    public GameObject simonObject;

    void CreatePlayer()
    {
        players.Add(Instantiate(playerPrefab));
        playersBasicConrtols.Add(players[players.Count - 1].GetComponent<SS_PlayerControl>());

        playersBasicConrtols[players.Count - 1].SetUpObject(simonObject);
        numberOfPlayers = players.Count;
    }

    void SortPlayerLoction()
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].transform.position == null)
            {
                Debug.Log("error the postion is null");
            }
            players[i].transform.position = new Vector2(((screenSize / numberOfPlayers) * ((i + 1) - (numberOfPlayers * 0.5f + 0.5f))), -3f);
        }
    }

    void ControlSet()
    {
        for(int i = 0; i < players.Count;i++)
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        screenSize = 20;
        if (gameBeging)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameBeging)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CreatePlayer();
                SortPlayerLoction();
            }
        }
    }
}
