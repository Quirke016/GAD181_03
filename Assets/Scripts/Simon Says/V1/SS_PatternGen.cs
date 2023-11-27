using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;



public class SS_PatternGen : MonoBehaviour
{
    public List<string> simonStartBag = new List<string>();
    public List<string> simonBag = new List<string>();
    public List<string> simonPattern = new List<string>();

    public GameObject Symbol;

    public bool simonTurn;
    public TextMeshProUGUI countdownText;

    bool RoundRuning;
    public bool randomBag;

    float turedrasion = 6;

    // Start is called before the first frame update
    void Start()
    {
        simonStartBag.Add("yellow");
        simonStartBag.Add("purple");
        simonStartBag.Add("blue");
        simonStartBag.Add("red");
        RoundRuning = false;

        //AddNewColorToPatten(randomBag);
        //AddNewColorToPatten(randomBag);
        simonTurn = false;

        //startTimeStopWatch = Time.time;
    }


    float SummonSymbol(string colorName, float duration, int index,float distance)
    {
        GameObject symbolObjectClone = Instantiate(Symbol, new Vector2(-10f-index* distance, 4f), Quaternion.identity);
        SS_SymbolControl symbolContral = symbolObjectClone.GetComponent<SS_SymbolControl>();
        symbolContral.states = GetColorNumber(colorName);
        symbolContral.DoAction(duration*((20.0f+index* distance) /20.0f));
        return duration * ((20.0f + index * distance) / 20.0f);

    }

    //private float startTimeStopWatch;
    //private bool isRunningStopWatch = false;
    //private float elapsedTimeStopWatch = 0f;





    /*public void ToggleStopWatch()
    {
        isRunningStopWatch = !isRunningStopWatch;
        if (isRunningStopWatch)
        {
            startTimeStopWatch = Time.time - elapsedTimeStopWatch;
        }
        else
        {
            elapsedTimeStopWatch = 0f;
            Debug.Log("stopwatahc reset");
        }
    }*/

    IEnumerator SummonColors(float duration)
    {
        if (RoundRuning)
        {
            float eachDuration = duration / simonPattern.Count;

            // Get the start time of the countdown
            float startTime = Time.time;
            int neg = 1;
            simonTurn = true;

            /*float symbolTime = (5 / duration) / simonPattern.Count;
            float wiatTime = (1 / 5) / simonPattern.Count;

    */
            /*float symbolTime = duration - wiatTime;
            float wiatTime = (1 / 5) / simonPattern.Count;*/

            /*timeThing1 / duration + 1 / timeThing1) = duration
            symbolTime /= 3;
            wiatTime /= 3;*/
            //ToggleStopWatch();
            for (int i = 0; i < simonPattern.Count; i++)
            {


                SummonSymbol(simonPattern[i], eachDuration, i, (10.0f / Mathf.Sqrt(simonPattern.Count)));

         

                // yield return new WaitForSeconds(wiatTime);\

                yield return null;
                RoundRuning = false;


            }



        }

        //float dura = SummonSymbol(simonPattern[simonPattern.Count - 1], eachDuration, simonPattern.Count - 1, (10.0f / Mathf.Sqrt(simonPattern.Count)));
        
        yield return new WaitForSeconds(6/2);
        //ToggleStopWatch();
        simonTurn = false;

        //yield return new WaitForSeconds(wiatTime+ symbolTime);
    
        //countdownText.text += " done";

        yield return null;
        

    }



    
  


    void SetUpStimonStartBag()
    {
        simonStartBag.Clear();
        simonStartBag.Add("yellow");
        simonStartBag.Add("purple");
        simonStartBag.Add("blue");
        simonStartBag.Add("red");
    }


    public int GetColorNumber(string color)
    {
        for (int i = 0; i < simonStartBag.Count; i++)
        {
            if (color == simonStartBag[i]) {  return i; }
        }

        return -1;
    }


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
        Debug.Log(simonBag.Count);
        //this make sure that hte simon bag is not empty
        if (simonBag.Count == 0)
        {

            simonBag = simonStartBag.ToList();
        }



        // this get the random color
        string newColor = GetRaindom(simonBag);


        if (randomBag)
        {

            //remove the color that is going be add
            simonBag.Remove(newColor);
        }

        




        //addinng new color to simonPattern
        simonPattern.Add(newColor);
    }

    void ListDebug(List<string> strings)
    {
        Debug.Log(string.Join(", ", strings));
    }

    
    public void StartEnemyRound()
    {
        if (!RoundRuning)
        {
            RoundRuning = true;
            AddNewColorToPatten(randomBag);
            ListDebug(simonPattern);
            StartCoroutine(SummonColors(turedrasion));
            turedrasion += simonPattern.Count / 10.0f;
        }
        
    }

    

    // Update is called once per frame
    void Update()
    {


/*
        if (Input.GetKeyDown(KeyCode.Space))
        {

            StartEnemyRound();


        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(SummonColors(turedrasion));


        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetUpStimonStartBag();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            SummonSymbol("yellow",3,1,4);
        }*/


     /*   if (isRunningStopWatch)
        {

            // Calculate the remaining time in seconds and milliseconds
            elapsedTimeStopWatch = Time.time - startTimeStopWatch;
            int seconds = (int)elapsedTimeStopWatch;
            int milliseconds = (int)((elapsedTimeStopWatch - seconds) * 1000);

            // Format the remaining time as a string
            string timeString = string.Format("{0:00}:{1:000}", seconds, milliseconds);
            countdownText.text = timeString;
        }*/
    }
}




