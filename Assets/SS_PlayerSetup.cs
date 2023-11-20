using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.InputSystem;

public class SS_PlayerSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        
        Debug.Log("Player Joined "+playerInput.playerIndex+"   "+ playerInput.gameObject.transform.position);
    }

}
