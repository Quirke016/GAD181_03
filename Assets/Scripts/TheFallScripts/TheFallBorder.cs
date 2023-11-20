using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class TheFallBorder : MonoBehaviour
{
    //this script kills the player if they go out of bounds

    public TheFallGameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<TheFallGameManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameManager.playersList[0]);
    }
}
