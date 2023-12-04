using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDirtETC : MonoBehaviour
{
    public GameObject joeDirtBlock;
    public PlayerMovementETC playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
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
