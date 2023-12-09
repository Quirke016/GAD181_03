using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDirtETC : MonoBehaviour
{
    public GameObject joeDirtBlock; // public game object for our dirt blocks
    public PlayerMovementETC playerMovement; // reference to the player movement script

    public void OnTriggerEnter2D(Collider2D other) // checks to see the number of the player that interacts with the block as well as if they have the player tag, if the player interacts with the block it is set to inactive
    {
        if (playerMovement.playerNo == 1 && other.CompareTag("Player"))
        {
            joeDirtBlock.SetActive(false);
        }
        if (playerMovement.playerNo == 2 && other.CompareTag("Player"))
        {
            joeDirtBlock.SetActive(false);
        }
        if (playerMovement.playerNo == 3 && other.CompareTag("Player"))
        {
            joeDirtBlock.SetActive(false);
        }
        if (playerMovement.playerNo == 4 && other.CompareTag("Player"))
        {
            joeDirtBlock.SetActive(false);
        }
    }
}
