using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;


using TMPro;

public class CG_Control : MonoBehaviour
{
    public int timeScore;
    public int timesCheated;

    public CG_Shuffle shuffleScript;
    public TextMeshProUGUI playerScoreboard;

    public int hp;

    CG_Cup lastButton = null;

    CG_EndGame endGameScript;


    // Start is called before the first frame update
    void Start()
    {

        hp = 3;

        xyOffSet = new Vector3(0.335f, 0.36f, 0f);
        nxyOffSet = new Vector3(-0.335f, 0.36f, 0f);

        endGameScript = GetComponent<CG_EndGame>();

    }



    void SetTexter(TextMeshProUGUI textBase, int playerNum, int score, int cheatCount, int hp)
    {
        textBase.text = "Player " + playerNum + " \n     hp: " + hp + "\nScore: " + score + "\nCheat: " + cheatCount;
    }

    [Range (1,11)]
    public int maxRound;
    Vector3 xyOffSet;
    Vector3 nxyOffSet;
    // Update is called once per frame
    void Update()
    {
        shuffleScript = GameObject.Find("Table").GetComponent<CG_Shuffle>(); // Get the renfenct to stuffle script component 
        bool showTimeC = shuffleScript.cupColors[0].showTime;
        bool selectTimeC = shuffleScript.cupColors[0].selectTime;
        

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);


        float distanceFromMid = 0.5f;



        if (worldPosition.x > 0)
        {

            transform.position = worldPosition - nxyOffSet;
            transform.localScale = new Vector3(-0.5f, transform.localScale.y, transform.localScale.z);

        }
        else
        {
            transform.position = worldPosition - xyOffSet;
            transform.localScale = new Vector3(0.5f, transform.localScale.y, transform.localScale.z);
        }


        if ((distanceFromMid * -1) < worldPosition.x && worldPosition.x < distanceFromMid)
        {
            Debug.Log("work6s");

            transform.localScale = new Vector3(transform.position.x * -0.5f, transform.localScale.y, transform.localScale.z);
            transform.position = worldPosition - new Vector3(nxyOffSet.x * transform.position.x, nxyOffSet.y, 0);
            //transform.position = transform.position* transform.position.x;
        }



        Collider2D col = Physics2D.OverlapPoint(transform.position);
        if (col != null)
        {
            CG_Cup cgCup = col.gameObject.GetComponent<CG_Cup>();





            if (cgCup != null && cgCup.selectTime == true) //
            {
                cgCup.ballSelected = true;
                lastButton = cgCup;



            }
            else
            {
                if (lastButton != null)
                    lastButton.ballSelected = false;
            }



            //check to see if you go the ext round with the cup withb the ballunder selected

            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (cgCup != null && cgCup.ballSelected)
                {
                    if (cgCup.ballUnderThis)
                    {
                        timeScore += 1;
                        Debug.Log("Points Scored is " + timeScore);
                        SetTexter(playerScoreboard, 1, timeScore, timesCheated, hp);

                    }
                    else
                    {
                        hp -= 1;
                        Debug.Log("hp reminding is " + hp);
                        SetTexter(playerScoreboard, 1, timeScore, timesCheated, hp);
                    }

                }


                /*
                                else if (cgCup == null || !cgCup.ballSelected)
                                    {
                                        hp -= 1;
                                        timeScore -= 1S;
                                        SetTexter(playerScoreboard, 1, timeScore, timesCheated, hp);
                                    }
                                }*/



            }
            else
            {
                if (lastButton != null)
                    lastButton.ballSelected = false;


            }




            if (Input.GetKeyDown(KeyCode.M) && selectTimeC && hp > 0)
            {
                timesCheated += 1;
                if (timesCheated > 1)
                {
                    hp -= 1;
                }

                Debug.Log("times cheat is " + timesCheated);
                SetTexter(playerScoreboard, 1, timeScore, timesCheated, hp);
            }


            Debug.Log("test02  ShowTime " + showTimeC + "     SelectTime " + selectTimeC);

            if (hp <= 0)
            {
                endGameScript.endGameStart(1, false, hp, timeScore, shuffleScript.RoundNumber);
            }

            if (shuffleScript.RoundNumber >= maxRound)
            {
                endGameScript.endGameStart(1, true, hp, timeScore, shuffleScript.RoundNumber);
            }
            

        }
    }
}
