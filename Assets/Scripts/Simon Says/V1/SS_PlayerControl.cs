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
    public Sprite wrongSpite;
    public Sprite rightSpite;




    // Start is called before the first frame update
    void Start()
    {

   


    }

    public void SetUpObject(GameObject objectGame)
    {
        simonObject = objectGame;
        patternSoftWere = simonObject.GetComponent<SS_PatternGen>();
        simonPattern = patternSoftWere.simonPattern;
        symbolContral = playerSymbol.GetComponent<SS_SymbolControl>();
        guessTime = true;
    }

    IEnumerator RightorWrong(bool isRight)
    {
        SpriteRenderer spiteRender = GetComponent<SpriteRenderer>();
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



    void AddColorToplayerList(string addColor)
    {
        if (addColor == simonPattern[playerGuesss.Count])
        {
            if (pointInRow < 10) { pointInRow += 1; }
            
            playerPoint += pointInRow;
            Debug.Log("the right color");
            StartCoroutine(RightorWrong(true));
            //PlaySymbolSound(addColor);
            symbolContral.states = patternSoftWere.GetColorNumber(addColor);
            symbolContral.buttonName.text = "" + pointInRow;
        }
        else
        {
            Debug.Log("not the right color");
            pointInRow = 0;
            StartCoroutine(RightorWrong(false));
            symbolContral.states = 4;
            




        }

        playerGuesss.Add(addColor);
        //ChangeSymbalColor(addColor, 0.5f);


        StartCoroutine(symbolContral.ChangeSize(0.5f, new Vector3(1f, 1f, 1f), new Vector3(2f, 2f, 2f)));

    }



    /* void ChangeSymbalColor(string colorName, float duration)
     {
         symbolContral.states = patternSoftWere.GetColorNumber(addColor);

         StartCoroutine(symbolContral.ChangeSize(duration, new Vector3(1f,1f,1f), new Vector3(2f,2f,2f)));

     }
 */
    public bool guessTime;


    

    // Update is called once per frame
    void Update()
    {
        symbolContral.buttonName.text = "" + pointInRow;
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(RightorWrong(true));
        }
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
                    playerPoint -= pointInRow;
                    pointInRow -= 1;
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
        
        Debug.Log("LEFT " + context);
    }
}
