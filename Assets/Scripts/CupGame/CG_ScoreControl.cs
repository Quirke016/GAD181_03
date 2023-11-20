using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CG_ScoreControl : MonoBehaviour
{
    GameObject[] Players = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        Players[0] = GameObject.Find("GC_cursor");
        Debug.Log(Players.Length + "test01");
    }



    void DetectIfPlayerCheats()
    {

    }

    void DetectIfPlayerScore()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
