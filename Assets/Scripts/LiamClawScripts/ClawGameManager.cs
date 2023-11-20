using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawGameManager : MonoBehaviour
{
    public ClawPlayerMovement player;
    public ClawNPC npc;
    public ClawNPCGrab grab;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<ClawPlayerMovement>();
        npc = FindObjectOfType<ClawNPC>();
        grab = FindObjectOfType<ClawNPCGrab>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            npc.npcActive = !npc.npcActive;
            Debug.Log("Shift pressed");
        }

        if (Input.GetKeyDown(KeyCode.E) && grab.isInTrigger == true && player.npcGrab == false && npc.npcPlaced == false)
        {
            npc.npcActive = false;
            player.npcGrab = true;
            Debug.Log("npc grabbed");
        }

        if (Input.GetKeyDown(KeyCode.E) && player.npcGrab == true && player.inZone == true)
        {
            player.npcGrab = false;
            npc.npcPlaced = true;
            Debug.Log("npc dropped");
        }
    }
}
