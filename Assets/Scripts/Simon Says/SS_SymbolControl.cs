﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SS_SymbolControl : MonoBehaviour
{
    [Range(0,4)]
    public int states = 0;
    Color statesColor = Color.black;
    public TextMeshPro buttonName;
    //Transform symbal3D;
    SS_SoundPlayer soundPlayer;
    string[] arrows;
    string[] keyNames;
    string[] symbalNameUseing;
    public bool isKeyNames;

    public string centerSymbolName="0";
    // Start is called before the first frame update
    void OnEnable()
    {
        arrows = new string[4];
        arrows[0] = "←";
        arrows[1] = "↑";
        arrows[2] = "↓";
        arrows[3] = "→";

        keyNames = new string[4];
        keyNames[0] = "A";
        keyNames[1] = "W";
        keyNames[2] = "S";
        keyNames[3] = "D";
        //isButtonLetter = false;

        soundPlayer = GetComponent<SS_SoundPlayer>();

        Transform childTransform = transform.Find("Text");
        //symbal3D = transform.Find("Sphere");

        buttonName = childTransform.GetComponent<TextMeshPro>();

        isKeyNames = true;
    }
    
    public void DoAction(float duration)
    {

        StartCoroutine(MoveToTarget(new Vector2(10f, transform.position.y), duration));
        StartCoroutine(ChangeSize(duration, new Vector3(1f, 1f, 1f), new Vector3(2f, 2f, 2f)));
        Destroy(this.gameObject, duration);
    }


    
   

    IEnumerator MoveToTarget(Vector2 target, float duration)
    {
        float timeElapsed = 0;

        Vector3 startingPos = transform.localPosition;

        while (timeElapsed < duration)
        {
            transform.localPosition = Vector2.Lerp(startingPos, target, timeElapsed / duration);

            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = target;

    }

    /*IEnumerator SizeChange(Vector2 targetSize, float duration)
    {
        float timeElapsed = 0;

        Vector2 startingSize = transform.localScale;

        while (timeElapsed < duration)
        {
            transform.localScale = Vector2.Lerp(startingSize, targetSize, timeElapsed / duration);

            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.localScale = targetSize;

    }*/


    // Update is called once per frame
    public bool isButtonLetter;
    public string symbolName;

    void Update()
    {
        if (!isKeyNames)
        {
            symbalNameUseing = arrows;
        }
        else
        {
            symbalNameUseing = keyNames;
        }
        if (states == 0)
        {
            statesColor = Color.yellow;
            if (isButtonLetter)
            {
                buttonName.text = symbolName;
            }
            
        }
        else if (states == 1)
        {
             statesColor = Color.magenta;
            if (isButtonLetter)
            {
                buttonName.text = symbolName;
            }
        }
        else if (states == 2)
        {
             statesColor = Color.blue;
            if (isButtonLetter)
            {
                buttonName.text = symbolName;
            }
        }
        else if (states == 3)
        {
             statesColor = Color.red;
            if (isButtonLetter)
            {
                buttonName.text = symbolName;
            }
        }
        else if(states == 4)
        {
            statesColor = Color.white;
            if (isButtonLetter)
            {
                buttonName.text = centerSymbolName;
            }
        }
        else
        {
             statesColor = Color.black;
        }

        GetComponent<Renderer>().material.SetColor("_Color", statesColor);
        GetComponent<Light>().color = statesColor;
        //symbal3D.GetComponent<Renderer>().material.SetColor("_Color", statesColor);
        //if (states != -1) { MoveToRightSide(2); }

    }
    public void ClickedTheButten(float duration)
    {
        StartCoroutine(ChangeSize(duration, new Vector3(1f, 1f, 1f), new Vector3(2f, 2f, 2f)));
    }

    public IEnumerator ChangeSize(float duration, Vector3 originalScale, Vector3 targetSize)
    {
        Light lightObject = GetComponent<Light>();
        
        //Vector3 originalScale = transform.localScale;
        float durationForEach = duration / 2;

        float timer = 0.0f;

        while (timer < durationForEach)
        {
            float t = timer / durationForEach;
            transform.localScale = Vector3.Lerp(originalScale, targetSize, t);
            lightObject.range = Mathf.Lerp(0,  15f, t);
            


            timer += Time.deltaTime;
            yield return null;
        }

        soundPlayer.PlaySymbolSound(states);

        timer = 0.0f;

        while (timer < durationForEach)
        {
            float t = timer / durationForEach;
            transform.localScale = Vector3.Lerp(originalScale * 2.0f, originalScale, t);
            timer += Time.deltaTime;
            lightObject.range = Mathf.Lerp(15f, 0, t);
            yield return null;
        }
    }
}



