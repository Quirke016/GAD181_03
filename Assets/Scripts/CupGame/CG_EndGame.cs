using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class CG_EndGame : MonoBehaviour
{
    public string scene;
    public GameObject endBackGroundObject;
    public GameObject endTextObject;
    TextMeshProUGUI endText;


    IEnumerator EndGame()
    {
        
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(scene);
    }

    public void endGameStart(int winingPlayerNumber, bool isWinner, int endHp, int endScore, int roundCount)
    {
        endBackGroundObject.SetActive(true);
        string winLose = "Winner";
        if (!isWinner) { winLose = "Loser"; }
        string hpText = endHp + "";
        if (endHp >= 0) { hpText = "dead"; }


        endText.text = winLose + " Player " + winingPlayerNumber + "\nEndHp: "+ hpText + "\nEndScore: "+ endScore+"/10\nRounds: "+ roundCount + "/10";
        
        StartCoroutine(EndGame());
    }

    // Start is called before the first frame update
    void Start()
    {
        endText = endTextObject.GetComponent<TextMeshProUGUI>();
        endBackGroundObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
