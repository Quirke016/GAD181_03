using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementETC : MonoBehaviour
{
    public DestroyDirtETC DestroyDirt; // reference to the destroy dirt script
    public int playerNo = 0; // public int for the player num value
    public bool canPlayerMove = true; // bool to enable whether the player can move or not
   


    // Update is called once per frame
    void Update()
    {
        
        PlayerControls(); // calls the player controls function
        
        PlayerMovementStop(); // calls/checks the player movement stop function
    }

   

    void PlayerControls() // player control function that has a switch that stores 4 cases inside of it, 1 for each player
    {
        switch (playerNo)
        {
           

            case 1:
                if (canPlayerMove == true) // checks to see if player can move is set to true
                {
                    if (playerNo == 1 && Input.GetKeyDown(KeyCode.S))
                    {
                        transform.Translate(0, -100 * Time.deltaTime, 0); // moves the player down on the y axis when button is pressed
                    }
                }

                break;

            case 2:
                if (canPlayerMove == true) // checks to see if player can move is set to true
                {
                    if (playerNo == 2 && Input.GetKeyDown(KeyCode.K))
                    {
                        transform.Translate(0, -100 * Time.deltaTime, 0); // moves the player down on the y axis when button is pressed
                    }
                }

                break;

            case 3:
                if (canPlayerMove == true) // checks to see if player can move is set to true
                {
                    if (playerNo == 3 && Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        transform.Translate(0, -100 * Time.deltaTime, 0); // moves the player down on the y axis when button is pressed
                }

                break;

            case 4:
                if (canPlayerMove == true) // checks to see if player can move is set to true
                {
                    if (playerNo == 4 && Input.GetKeyDown(KeyCode.F))
                    {
                        transform.Translate(0, -100 * Time.deltaTime, 0); // moves the player down on the y axis when button is pressed
                    }
                }

                break;
            
        }
       
    }

    void PlayerMovementStop() // player movement stop function that checks to see if player can move is set to false, when false players are stuck at their current positions 
    {
        if (canPlayerMove == false)
        {
            transform.position = gameObject.transform.position;
        }
    }
        
}
