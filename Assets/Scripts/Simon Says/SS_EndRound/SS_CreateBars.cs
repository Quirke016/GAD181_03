using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class SS_CreateBars : MonoBehaviour
{
    public int numberOfPlayers= 2;
    float screenSize;
    GameObject[] playerBars;
    Slider[] playerSliders;
    //GameObject[] players;
    public GameObject playerBarPrefab;

    public GameObject canvas;

    int[] playersPoints; 


    void SetUp(int numberoPlayer, int[] points)
    {
        numberOfPlayers = numberoPlayer;

        playerBars = new GameObject[numberOfPlayers];
        playersPoints = points;
        playerSliders = new Slider[numberOfPlayers];


        for (int i = 0; i < numberOfPlayers; i++)
        {
            Debug.Log("Created a new player");
            Vector3 locPos = new Vector3(((screenSize / numberOfPlayers) * ((i + 1) - (numberOfPlayers * 0.5f + 0.5f))), 0f, 0f);

            Quaternion newRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));

            playerBars[i] = Instantiate(playerBarPrefab, CameraToCanvasPosition(locPos, canvas.GetComponent<Canvas>()), newRotation, canvas.transform);
            playerSliders[i] = playerBars[i].GetComponent<Slider>();


            

        }

    }


    // Start is called before the first frame update
    void Start()
    {
        screenSize = 20;

/*
        //players = new GameObject[numberOfPlayers];
        playerBars = new GameObject[numberOfPlayers];
        playersPoints = new int[numberOfPlayers];
        playerSliders = new Slider[numberOfPlayers];
        for (int i = 0; i < numberOfPlayers; i++)
        {
            Debug.Log("Created a new player");
            Vector3 locPos = new Vector3(((screenSize / numberOfPlayers) * ((i + 1) - (numberOfPlayers * 0.5f + 0.5f))), 0f, 0f);

            Quaternion newRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));

            playerBars[i] = Instantiate(playerBarPrefab, CameraToCanvasPosition(locPos, canvas.GetComponent<Canvas>()), newRotation, canvas.transform);
            playerSliders[i] = playerBars[i].GetComponent<Slider>();
            
            string ne = "" + i+ "  pos 1";
            InteractWithCube(locPos, ne);
            ne = "" + i + "  pos 2";
            InteractWithCube(CameraToCanvasPosition(locPos, canvas.GetComponent<Canvas>()), ne);


            playersPoints[i] = i * 10;

        }*/


        /*int maxValueSlider = playersPoints.Max();
        for (int i = 0; i < numberOfPlayers; i++)
        {
            playerSliders[i].maxValue = maxValueSlider;

            StartCoroutine(IncreaseSlider(playersPoints[i], 1, playerSliders[i]));
        }*/
            
    }

    public void StartEndOfRound(int numberoPlayer, int[] points)
    {
        SetUp(numberoPlayer, points);

        int maxValueSlider = playersPoints.Max();
        for (int i = 0; i < numberOfPlayers; i++)
        {
            playerSliders[i].maxValue = maxValueSlider;

            StartCoroutine(IncreaseSlider(playersPoints[i], 1, playerSliders[i]));
        }
    }


    IEnumerator IncreaseSlider(int number, float timeInSeconds, Slider sliderV)
    {
        float elapsedTime = 0f;
        float startValue = sliderV.value;
        float endValue = number;

        while (elapsedTime < timeInSeconds)
        {
            sliderV.value = Mathf.Lerp(startValue, endValue, elapsedTime / timeInSeconds);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        sliderV.value = endValue;
    }

    public void InteractWithCube(Vector3 location, string name)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = location;
        cube.name = name;
    }


 

    public Vector2 CameraToCanvasPosition(Vector3 cameraPosition, Canvas canvas)
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(cameraPosition);
        RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();
        Vector2 canvasPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, screenPoint, null, out canvasPosition);
        canvasPosition.x = canvasPosition.x + 960;
        canvasPosition.y = canvasPosition.y + 580;
        return canvasPosition;
    }



    // Update is called once per frame
    void Update()
    {


    }
}


