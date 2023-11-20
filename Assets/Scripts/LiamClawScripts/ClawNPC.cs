using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawNPC : MonoBehaviour
{
    public ClawPlayerMovement player;
    public ClawNPCGrab grab;
    public bool npcActive = true;
    public bool npcPlaced = false;
    public float npcX;
    public float npcY;
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
