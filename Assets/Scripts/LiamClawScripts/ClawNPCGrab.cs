using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawNPCGrab : MonoBehaviour
{
    public ClawPlayerMovement player;
    public ClawNPC npc;
    public bool isInTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<ClawPlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInTrigger= false;
    }
}
