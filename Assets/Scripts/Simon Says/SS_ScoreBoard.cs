using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class SS_ScoreBoard : MonoBehaviour
{
    //[Range(1, 4)]
    public int numberOfPlayers;
    GameObject[] players;
    TextMeshPro[] scoreBoardList;
    public GameObject playerPrefab;
    SS_PlayerControl[] playerControls;
    float screenSize;
    public GameObject simonObject;
    int[] playerRowPoint;
    int[] playerPoints;
    SS_PatternGen patternSoftWere;
    int roundCounter;
    SS_CreateBars endBarsContol;
    public GameObject onScreenTextObject;
    TextMeshProUGUI onScreenText;
    public GameObject onScreenInstructions;


    void SetTexter(TextMeshPro textBase, int playerNum, int score, int cheatCount)
    {
        textBase.text = "Player " + playerNum + "\nScore: " + score + "\nPointInRow: " + cheatCount;
    }

    void GameSetup(int numberOfPlayers)
    {


        endBarsContol = GetComponent<SS_CreateBars>();
        patternSoftWere = simonObject.GetComponent<SS_PatternGen>();

        screenSize = 20;
        players = new GameObject[numberOfPlayers];
        playerControls = new SS_PlayerControl[numberOfPlayers];
        scoreBoardList = new TextMeshPro[numberOfPlayers];
        playerPoints = new int[numberOfPlayers];
        playerRowPoint = new int[numberOfPlayers];
        

        for (int i = 0; i < numberOfPlayers; i++)
        {
            Debug.Log("Created a new player");
            players[i] = Instantiate(playerPrefab, new Vector2(((screenSize / numberOfPlayers) * ((i + 1) - (numberOfPlayers * 0.5f + 0.5f))), -3f), Quaternion.identity);


            playerControls[i] = players[i].GetComponent<SS_PlayerControl>();
            playerControls[i].simonObject = simonObject;

            //textMesh.text = "got them";
            playerPoints[i] = playerControls[i].playerPoint;

     
            scoreBoardList[i] = players[i].transform.Find("ScorboardText").GetComponent<TextMeshPro>();
        }
    }


    void StartEnemyRound()
    {
        for (int i = 0; i < numberOfPlayers;i++)
        {
            playerControls[i].playerGuesss.Clear();
            playerControls[i].guessTime = true;
        }
        patternSoftWere.StartEnemyRound();

    }


    


    IEnumerator ShowBigText(string showThis, float duration)
    {
        onScreenText.text = showThis;
        onScreenTextObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        onScreenTextObject.SetActive(false);
    }

    IEnumerator InstructionScreen()
    {
        onScreenInstructions.SetActive(true);
        while (!Input.anyKey)
        {
            yield return null;
        }
        onScreenInstructions.SetActive(false);
        StartCoroutine(StartGame());
    }
    IEnumerator StartGame()
    {
        inIntro = true;
        StartCoroutine(ShowBigText("3", 0.9f));
        yield return new WaitForSeconds(1);
        StartCoroutine(ShowBigText("2", 0.9f));
        yield return new WaitForSeconds(1);
        StartCoroutine(ShowBigText("1", 0.9f));
        yield return new WaitForSeconds(1);
        StartCoroutine(ShowBigText("Start", 0.5f));
        yield return new WaitForSeconds(0.25f);
        inIntro = false;
        //StartEnemyRound();
    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }

    bool CheckIfCanNextRound()
    {
        bool[] playerModes = new bool[numberOfPlayers];
        for (int i = 0; i < numberOfPlayers; i++)
        {
            playerModes[i] = playerControls[i].guessTime;
        }

        int playerModesFalseCount = playerModes.Count(b => b == false);
        if (playerModesFalseCount == playerModes.Count())
        {
            return true;
        }
        return false;
    }

   
    void Start()
    {
        inIntro = true;
        GameSetup(numberOfPlayers);
        onScreenText = onScreenTextObject.GetComponent<TextMeshProUGUI>();



        inEndGame = false;
        StartCoroutine(InstructionScreen());
    }

    [SerializeField] string scene;
    bool inIntro;
    bool inEndGame;
    [Range(1,10)]
    public int maxRound;
    // Update is called once per frame
    void Update()
    {
        Debug.Log("checking if it work " + CheckIfCanNextRound());
        for (int i = 0;i < numberOfPlayers;i++)
        {
            playerPoints[i] = playerControls[i].playerPoint;
            playerRowPoint[i] = playerControls[i].pointInRow;
            SetTexter(scoreBoardList[i], i + 1, playerPoints[i], playerRowPoint[i]);
        }

        if (!patternSoftWere.simonTurn && CheckIfCanNextRound() && roundCounter <= maxRound && !inIntro)
        {
            StartEnemyRound();
            roundCounter += 1;
        }


        Debug.Log("roundcount is " + roundCounter);
        if (!(roundCounter <= maxRound) && !inEndGame && CheckIfCanNextRound())
        {
            Debug.Log("game over at round " + roundCounter);
            endBarsContol.StartEndOfRound(numberOfPlayers, playerPoints);
            inEndGame = true;

            StartCoroutine(EndGame());
        }
    }
}
