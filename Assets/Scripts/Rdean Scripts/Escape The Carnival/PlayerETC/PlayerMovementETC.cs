using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementETC : MonoBehaviour
{
    public DestroyDirtETC DestroyDirt;
    public int playerNo = 0;
    //[SerializeField] private GameObject blockToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControls();
    }

   

    void PlayerControls()
    {
        switch (playerNo)
        {
            case 1:
                if(playerNo == 1 && Input.GetKeyDown(KeyCode.S))
                {
                    transform.Translate(0, -100 * Time.deltaTime, 0);
                }
                 
                break;

            case 2:
                if (playerNo == 2 && Input.GetKeyDown(KeyCode.K))
                {
                    transform.Translate(0, -100 * Time.deltaTime, 0);
                }

                break;

        }

       
    }
}
