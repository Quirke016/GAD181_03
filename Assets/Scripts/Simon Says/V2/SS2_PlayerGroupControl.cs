using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class SS2_PlayerGroupControl : MonoBehaviour
{
    public List<GameObject> players = new List<GameObject>();
    public List<SS2_SimonBoard> playersBasicConrtols = new List<SS2_SimonBoard>();

    public int numberOfPlayers;
    float screenSize;
    public GameObject playerPrefab;
    public bool gameBeging;
    public GameObject simonObject;

    List<int[]> keyControls = new List<int[]>();


    SS2_PattenGen patternSoftWere;
    public List<string>[] playerGuesss = new List<string>[0];
    List<string> simonPattern;
    public int[] playerPoint;
    

    public int[] pointInRows;

    public Sprite wrongSpite;
    public Sprite rightSpite;
    bool[] guessTime = new bool[0];
    public bool guessTimeTotal;

    void CreatePlayer()
    {
        players.Add(Instantiate(playerPrefab));
        playersBasicConrtols.Add(players[players.Count - 1].GetComponent<SS2_SimonBoard>());

        numberOfPlayers = players.Count;

        playerGuesss = new List<string>[numberOfPlayers];
        playerPoint = new int[numberOfPlayers];
        pointInRows = new int[numberOfPlayers];
        guessTime = new bool[numberOfPlayers];
        for(int i=0;i<numberOfPlayers; i++)
        {
            playerGuesss[i] = new List<string>();
        }
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

    /// <summary>
    /// this funstion is to setup parts of script:
    /// </summary>
    public void SetUpObject()
    {
        patternSoftWere = simonObject.GetComponent<SS2_PattenGen>(); //geting refence to the patterngen script
        simonPattern = patternSoftWere.simonPattern; // get refnce to pattern that is being gentreated
        /*for (int i = 0; i < players.Count; i++)
        {
            symbolContral.Add(playerSymbol.GetComponent<SS_SymbolControl>());

        }*/

    }

    IEnumerator RightorWrong(bool isRight,int playerCount)
    {
        if (playerCount >= numberOfPlayers)
        {
            Debug.Log("Error number give is higher then number of players");
        }

        SpriteRenderer spiteRender = players[playerCount].GetComponent<SpriteRenderer>();
        if (isRight)
        {
            spiteRender.sprite = rightSpite;
        }
        else
        {
            spiteRender.sprite = wrongSpite;
        }
        spiteRender.enabled = true;
        yield return new WaitForSeconds(0.2f);
        spiteRender.enabled = false;
    }



    void AddColorToplayerList(string addColor, int playerNumber)
    {
        if (addColor == simonPattern[playerGuesss[playerNumber].Count])
        {
            if (pointInRows[playerNumber] < 10) { pointInRows[playerNumber] += 1; }

            playerPoint[playerNumber] += pointInRows[playerNumber];
            Debug.Log("the right color");
            StartCoroutine(RightorWrong(true, playerNumber));
            //PlaySymbolSound(addColor);
            playersBasicConrtols[playerNumber].SymbolClicked(patternSoftWere.GetColorNumber(addColor), 1);
            
        }
        else
        {
            Debug.Log("not the right color");
            pointInRows[playerNumber] = 0;
            StartCoroutine(RightorWrong(false, playerNumber));
            playersBasicConrtols[playerNumber].SymbolClicked(patternSoftWere.GetColorNumber(addColor), 1);
        }

        playerGuesss[playerNumber].Add(addColor);
        //ChangeSymbalColor(addColor, 0.5f);



        //StartCoroutine(symbolContral.ChangeSize(0.5f, new Vector3(1f, 1f, 1f), new Vector3(2f, 2f, 2f)));

    }

    void InputStuff(int playerNumber)
    {
        if (playerGuesss[playerNumber].Count < simonPattern.Count)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {
                AddColorToplayerList("yellow", playerNumber);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                AddColorToplayerList("red", playerNumber);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                AddColorToplayerList("blue", playerNumber);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                AddColorToplayerList("purple", playerNumber);
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                AddColorToplayerList(simonPattern[playerGuesss[playerNumber].Count], playerNumber);
                playerPoint[playerNumber] -= pointInRows[playerNumber];
                pointInRows[playerNumber] -= 1;
            }
        }
        else
        {
            //playerGuesss[numberOfPlayers] = new string[];
            guessTime[playerNumber] = false;
        }
    }

    public void GuessReset()
    {
        for (int i = 0; i < guessTime.Length; i++)
        {
            guessTime[i] = true;
        }
    }

    void CheckIfCanNextRound()
    {
        int count = 0;
        for(int i = 0; i < guessTime.Length;i++) 
        {
            if (guessTime[i])
            {
                count += 1;
            }
        }
        
        if ((count == 0))
        {
            guessTimeTotal = true;
        }
        else
        {
            guessTimeTotal = false;
        }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        SetUpObject();
        
    }

    // Update is called once per frame
    void Update()
    {

        CheckIfCanNextRound();
        if (gameBeging)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CreatePlayer();
                SortPlayerLoction();
                
            }
        }

        //symbolContral.buttonName.text = "" + pointInRows[playerNumber];


        if (!patternSoftWere.simonTurn)
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                if (guessTime[i])
                {
                    InputStuff(i);
                }
                
            }
            
        }
    }
}
