using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementETC : MonoBehaviour
{
    public DestroyDirtETC DestroyDirt;
    public int playerNo = 0;
    public bool canPlayerMove = true;
   
    //[SerializeField] private GameObject blockToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        PlayerControls();
        
        PlayerMovementStop();
    }

   

    void PlayerControls()
    {
        switch (playerNo)
        {
           

            case 1:
                if (canPlayerMove == true)
                {
                    if (playerNo == 1 && Input.GetKeyDown(KeyCode.S))
                    {
                        transform.Translate(0, -100 * Time.deltaTime, 0);
                    }
                }

                break;

            case 2:
                if (canPlayerMove == true)
                {
                    if (playerNo == 2 && Input.GetKeyDown(KeyCode.K))
                    {
                        transform.Translate(0, -100 * Time.deltaTime, 0);
                    }
                }

                break;

            case 3:
                if (canPlayerMove == true)
                {
                    if (playerNo == 3 && Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        transform.Translate(0, -100 * Time.deltaTime, 0);
                    }
                }

                break;

            case 4:
                if (canPlayerMove == true)
                {
                    if (playerNo == 4 && Input.GetKeyDown(KeyCode.F))
                    {
                        transform.Translate(0, -100 * Time.deltaTime, 0);
                    }
                }

                break;
            
        }
       
    }

    void PlayerMovementStop()
    {
        if (canPlayerMove == false)
        {
            transform.position = gameObject.transform.position;
        }
    }
        
}
