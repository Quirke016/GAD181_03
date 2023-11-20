using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawNPC : MonoBehaviour
{

    public bool npcActive = true;
    private float npcX;
    private float npcY;
    private float npcSpeed = 0.001f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(npcX, npcY);

        if (Input.GetKey(KeyCode.Space))
        {
            npcActive = false;
        }

        if (npcActive == true)
        {

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
