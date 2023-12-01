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

    KeyCode[][] playerControlsKeys;

    string[][] stringKeyNames;

    void SetUpkeys()
    {
        playerControlsKeys = new KeyCode[4][];

        for (int i = 0;  i < 4; i++) 
        {
            playerControlsKeys[i] = new KeyCode[4];

        }
        stringKeyNames = new string[4][];
        for (int i = 0; i < 4; i++)
        {
            stringKeyNames[i] = new string[4];

        }

        //Player 1 controllers
        playerControlsKeys[0][0] = KeyCode.A; // left
        playerControlsKeys[0][1] = KeyCode.D; // right
        playerControlsKeys[0][2] = KeyCode.S; // down
        playerControlsKeys[0][3] = KeyCode.W; // up

        stringKeyNames[0][0] = "A"; // left
        stringKeyNames[0][1] = "W"; // up
        stringKeyNames[0][2] = "S"; // down
        stringKeyNames[0][3] = "D"; // right



        //Player 2 controllers
        playerControlsKeys[1][0] = KeyCode.LeftArrow;
        playerControlsKeys[1][1] = KeyCode.RightArrow; 
        playerControlsKeys[1][2] = KeyCode.DownArrow;
        playerControlsKeys[1][3] = KeyCode.UpArrow;

        stringKeyNames[1][0] = "\"<\"";
        stringKeyNames[1][1] = "\"/\\\""; // up
        stringKeyNames[1][2] = "\"\\/\""; // down
        stringKeyNames[1][3] = "\">\""; // right






        //Player 3 controllers
        playerControlsKeys[2][0] = KeyCode.G; //left
        playerControlsKeys[2][1] = KeyCode.J; // right
        playerControlsKeys[2][2] = KeyCode.H; //down
        playerControlsKeys[2][3] = KeyCode.Y;

        stringKeyNames[2][0] = "G";
        stringKeyNames[2][1] = "Y"; // up
        stringKeyNames[2][2] = "H"; // down
        stringKeyNames[2][3] = "J"; // right


        //Player 4 controllers
        playerControlsKeys[3][0] = KeyCode.L; // left
        playerControlsKeys[3][1] = KeyCode.Quote; // right
        playerControlsKeys[3][2] = KeyCode.Semicolon; // down
        playerControlsKeys[3][3] = KeyCode.P; // up


        stringKeyNames[3][0] = "L"; // left
        stringKeyNames[3][1] = "P"; // up
        stringKeyNames[3][2] = ";"; // down
        stringKeyNames[3][3] = "'"; // right
    }

    void SetButtonNames()
    {
        for (int i = 0;  i < numberOfPlayers; i++)
        {
            for (int j = 0; j < playerControlsKeys[i].Length; j++)
            {

                playersBasicConrtols[i].SetButtonNumberToText(j, stringKeyNames[i][j]);
            }
            
        }
    }

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

           // Debug.Log("Seting " + players[i].name+ " loction to "+ new Vector2(((screenSize / numberOfPlayers) * ((i + 1) - (numberOfPlayers * 0.5f + 0.5f))), -3f))
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

        Debug.Log("test2 addColor " + addColor + " SimonColor " + simonPattern[playerGuesss[playerNumber].Count]);
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
            StartCoroutine(playersBasicConrtols[playerNumber].WrongAswer());
        }

        playerGuesss[playerNumber].Add(addColor);
        //ChangeSymbalColor(addColor, 0.5f);



        //StartCoroutine(symbolContral.ChangeSize(0.5f, new Vector3(1f, 1f, 1f), new Vector3(2f, 2f, 2f)));

    }

    void InputStuff(int playerNumber)
    {
        playersBasicConrtols[playerNumber].SetCenter(simonPattern.Count-playerGuesss[playerNumber].Count + "");

        if (playerGuesss[playerNumber].Count < simonPattern.Count)
        {

            if (Input.GetKeyDown(playerControlsKeys[playerNumber][0]))
            {
                AddColorToplayerList("yellow", playerNumber);
            }
            else if (Input.GetKeyDown(playerControlsKeys[playerNumber][1]))
            {
                AddColorToplayerList("red", playerNumber);
            }
            else if (Input.GetKeyDown(playerControlsKeys[playerNumber][2]))
            {
                AddColorToplayerList("blue", playerNumber);
            }
            else if (Input.GetKeyDown(playerControlsKeys[playerNumber][3]))
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
            Debug.Log("player "+ playerNumber + " there guesss are "+ string.Join(", ", playerGuesss[playerNumber].ToArray()));
            //playerGuesss[numberOfPlayers] = new string[];
            guessTime[playerNumber] = false;
        }
    }

    public void GuessReset()
    {
        for (int i = 0; i < guessTime.Length; i++)
        {
            guessTime[i] = true;
            playerGuesss[i].Clear();
        }

    }

    public void CheckIfCanNextRound()
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
        screenSize = 20;
        SetUpkeys();

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.L))
        {
            SortPlayerLoction();
        }*/

        SetButtonNames();
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
               /* else
                {
                    playersBasicConrtols[i].SetCenter("0");
                }*/
                
            }
            
        }
    }
}
