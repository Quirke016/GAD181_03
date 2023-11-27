using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawNPC : MonoBehaviour
{
    public ClawPlayerMovement player;
    public ClawNPCGrab grab;
    public bool npcActive = true;
    public bool npcPlaced = false;
    public int npcMoveInt;
    public float npcX;
    public float npcY;
    public float npcTimer;
    public float gameTimer;
    private float npcSpeed = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<ClawPlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(npcX, npcY);
        gameTimer = Time.time;

        if (Input.GetKeyDown(KeyCode.E) && grab.isInTrigger == true && player.npcGrab == false && npcPlaced == false)
        {
            npcActive = false;
            player.npcGrab = true;
            Debug.Log("npc grabbed");
        }

        if (npcActive == false && player.npcGrab == true && grab.isInTrigger == true && npcPlaced == false)
        {
            transform.position = player.transform.position;
            npcX = player.transform.position.x;
            npcY = player.transform.position.y;
            Debug.Log("npc held");
        }

        if (Input.GetKeyDown(KeyCode.E) && grab.isInTrigger == true && player.inZone == true)
        {
            npcPlaced = true;
        }

        if (npcMoveInt == 1)
        {
            NPCMoveUp();
        }
        else if (npcMoveInt == 2)
        {
            NPCMoveDown();
        }
        else if (npcMoveInt == 3)
        {
            NPCMoveLeft();
        }
        else if (npcMoveInt == 4)
        {
            NPCMoveRight();
        }

        if (npcActive == true)
        {
            if (npcTimer < gameTimer)
            {
                npcTimer = gameTimer + (Random.Range(0.2f, 1));
                npcMoveInt = (Random.Range(1, 5));
            }
        }
        else if (npcActive == false)
        {
            npcMoveInt = 0;
        }
    }

    void NPCMoveUp()
    {
        npcY = npcY + npcSpeed;
    }
    void NPCMoveDown()
    {
        npcY = npcY - npcSpeed;
    }

    void NPCMoveRight()
    {
        npcX = npcX + npcSpeed;
    }

    void NPCMoveLeft()
    {
        npcX = npcX - npcSpeed;
    }
}
