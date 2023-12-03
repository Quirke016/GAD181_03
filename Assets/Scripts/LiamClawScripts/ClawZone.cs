using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawZone : MonoBehaviour
{
    public ClawPlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<ClawPlayerMovement>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.inZone = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.inZone = false;
    }
}
