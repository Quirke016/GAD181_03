using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class SS2_SimonBoard : MonoBehaviour
{
    public GameObject[] symbols;

    public SS_SymbolControl[] symbolControls;
    IEnumerator WrongAswer()
    {
        symbols[4].SetActive(true);
        SymbolClicked(4);
        yield return new WaitForSeconds(1f);
        symbols[4].SetActive(false);

    }

    public void SymbolClicked(int buttonNumber, float duration = 1)
    {
        symbolControls[buttonNumber].ClickedTheButten(duration);
    }

    // Start is called before the first frame update
    void Start()
    {
        symbolControls = new SS_SymbolControl[symbols.Length];
        for (int i = 0;i < symbols.Length;i++) 
        { 
            symbolControls[i] = symbols[i].GetComponent<SS_SymbolControl>(); 
            if (symbolControls[i] == null)
            {
                Debug.Log("Error the symbol contorl cant be refenced "+ i);
            }
        }
        symbols[4].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.G)) 
        {
            Debug.Log("TestRun " + symbolControls.Count());
            StartCoroutine(WrongAswer());
            //SymbolClicked(0);
            
        }*/
    }
}
