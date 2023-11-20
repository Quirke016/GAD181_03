using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SS_PlayerControl : MonoBehaviour
{
    SS_PatternGen patternSoftWere;
    public List<string> playerGuesss = new List<string>();
    List<string> simonPattern;
    public GameObject simonObject;
    public int playerPoint;
    public GameObject playerSymbol;
    SS_SymbolControl symbolContral;

    public int pointInRow;



    // Start is called before the first frame update
    void Start()
    {
        patternSoftWere =  simonObject.GetComponent<SS_PatternGen>();
        simonPattern = patternSoftWere.simonPattern;
        symbolContral = playerSymbol.GetComponent<SS_SymbolControl>();
        guessTime = true;
    }


    void AddColorToplayerList(string addColor)
    {
        if (addColor == simonPattern[playerGuesss.Count])
        {
            if (pointInRow < 10) { pointInRow += 1; }
            
            playerPoint += pointInRow;
            Debug.Log("the right color");
            

        }
        else
        {
            Debug.Log("not the right color");
            pointInRow = 0;

        }

        playerGuesss.Add(addColor);
        ChangeSymbalColor(addColor, 0.5f);

    }



    void ChangeSymbalColor(string colorName, float duration)
    {
        
        symbolContral.states = patternSoftWere.GetColorNumber(colorName);
        StartCoroutine(symbolContral.ChangeSize(duration, new Vector3(1f,1f,1f), new Vector3(2f,2f,2f)));

    }

    public bool guessTime;


    

    // Update is called once per frame
    void Update()
    {
        Debug.Log("player guess " + playerGuesss.Count + "    Simon pattern " + simonPattern.Count);
        Debug.Log("Count " + (playerGuesss.Count <= simonPattern.Count));
        if (!patternSoftWere.simonTurn)
        {
            if (playerGuesss.Count <   simonPattern.Count)
            {
                
                if (Input.GetKeyDown(KeyCode.A))
                {
                    AddColorToplayerList("yellow");
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    AddColorToplayerList("red");
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    AddColorToplayerList("blue");
                }
                else if (Input.GetKeyDown(KeyCode.W))
                {
                    AddColorToplayerList("purple");
                }
                else if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    AddColorToplayerList(simonPattern[playerGuesss.Count]);
                    playerPoint -= 1;
                }
            }
            else
            {
                guessTime = false; 
            }
        }
        


    }

    public void Left(InputAction.CallbackContext context)
    {
        Debug.Log("LEFT");
    }
}
