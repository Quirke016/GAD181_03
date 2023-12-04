using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class SS2_PattenGen : MonoBehaviour
{
    // the first refences for the list of symbols
    public List<string> simonStartBag = new List<string>();

    // This refence is for simonbal for so that the can do set bag 
    public List<string> simonBag = new List<string>();

    // refence to full simoned patten
    public List<string> simonPattern = new List<string>();



    public bool simonTurn;

    public bool randomBag;

    SS2_SimonBoard simonBoard;

    //public GameObject simonsSymbols;
    // Start is called before the first frame update
    void Start()
    {
        SetUpStimonStartBag();

        simonBoard = GetComponent<SS2_SimonBoard>();
        simonTurn = false;
    }

    /// <summary>
    /// SetUpStimonStartBag is for seting simonStartBag
    /// </summary>
    void SetUpStimonStartBag()
    {
        simonStartBag.Clear();
        simonStartBag.Add("yellow");
        simonStartBag.Add("purple");
        simonStartBag.Add("blue");
        simonStartBag.Add("red");
    }
    /// <summary>
    /// this funstion to convert the color string ot a int
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public int GetColorNumber(string color)
    {
        for (int i = 0; i < simonStartBag.Count; i++)
        {
            if (color == simonStartBag[i]) { return i; }
        }

        return -1;
    }

    /// <summary>
    /// this funstion get random string form the i nputed string list
    /// </summary>
    /// <param name="strings"></param>
    /// <returns></returns>
    string GetRaindom(List<string> strings)
    {
        int randomNum = Random.Range(0, strings.Count);
        Debug.Log("random number " + randomNum);
        Debug.Log("stringCount number " + strings.Count);


        return strings[randomNum];
    }

    /// <summary>
    /// this funstion add a random color ot the pattern
    /// it has two mode randomBag and pure Random
    /// randombag use the tertis random funstion were that there will be no repeats
    /// </summary>
    /// <param name="randomBag"></param>
    void AddNewColorToPatten(bool randomBag = false)
    {
        //this make sure that hte simon bag is not empty
        if (simonBag.Count == 0)
        {

            simonBag = simonStartBag.ToList(); //this makes a copy of simonStartBag
        }



        // this get the random color
        string newColor = GetRaindom(simonBag);


        if (randomBag)
        {

            //remove the color that is going be add
            simonBag.Remove(newColor);
        }


        // Update is called once per frame

        //addinng new color to simonPattern
        simonPattern.Add(newColor);
    }


    

    IEnumerator ShowPattern(float speed, float duration)
    {
        // Get the start time of the countdown
 
        simonTurn = true;

        float eachDuration = duration / simonPattern.Count * speed;

        for (int i = 0; i < simonPattern.Count; i++)
        {

            simonBoard.SymbolClicked(GetColorNumber(simonPattern[i]), duration);
            yield return new WaitForSeconds(duration+Mathf.Sqrt(duration));


        }


        //yield return new WaitForSeconds(6 / 2);
        //ToggleStopWatch();
        simonTurn = false;

        //yield return null;


    }

    /// <summary>
    /// This funstion started the enemy (Simon's) Round 
    /// </summary>
    public void StartEnemyRound()
    {
        AddNewColorToPatten(randomBag);
        StartCoroutine(ShowPattern(simonPattern.Count+3, 1/ Mathf.Sqrt(simonPattern.Count)));

    }
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.G))
        {
            StartEnemyRound();

        }*/
    }
}

